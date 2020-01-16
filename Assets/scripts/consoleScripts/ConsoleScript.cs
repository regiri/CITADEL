using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using WindowsInput;

public class ConsoleScript : MonoBehaviour
{
    private InputField input;
    private SpriteRenderer screenRed, screenGreen;
    private Button butNext, butOK, butExitR, butExitG;
    private InputSimulator inputSimulator = new InputSimulator();
    private Canvas canvas;
    private GameObject hero;
    private int attempts = 0;
    public int score = 14;
    //всё далее должно храниться в xml
    private string error = "\n\nFatal error code DI35: encoding error.\nCannot read inner code files: unknown symbol ‘?’.";
    private string codeTask = @"# Python 3.7
global board


def draw_board():
    print('-------------')
    for i in ?????(3):
        print('|', board[0 + i * 3], '|', board[1 + i * 3], '|', board[2 + i * 3], '|')
        print('-------------')


??? take_input(player_token) :
    valid = False
    while ??? valid:
        player_answer = input('Куда поставим ' + player_token + '?')
        ???:
            player_answer = ???(player_answer)
        except:
            print('Некорректный ввод. Вы уверены, что ввели число?')
            continue
        if 1 <= player_answer <= 9:
            if str(board[player_answer - 1]) not in 'XO':
                board[player_answer - 1] = player_token
                valid = True
            ????:
                print('Эта клеточка уже занята')
        ????:
            print('Некорректный ввод. Введите число от 1 до 9 чтобы походить.')


def check_win():
    win_coord = ((0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6))
    ??? each ?? win_coord:
        if board[each[0]] == board[each[1]] == board[each[2]]:
            return board[each[0]]
    ????? False


def main() :
    counter = 0
    win = False
    ?????? not win:
        draw_board()
        if counter % 2 == 0:
            take_input('X')
        ????:
            take_input('O')
        counter += 1
        if counter > 4:
            tmp = check_win()
            if tmp:
                ?????(tmp, 'выиграл!')
                win = True
                break
        if counter == 9:
            ?????(' Ничья!')
            ?????
    draw_board()


if __name__ == '__main__':
    board = list(range(1, 10))
    ????()";
    private string codeAns = @"# Python 3.7
global board


def draw_board():
    print('-------------')
    for i in range(3):
        print('|', board[0 + i * 3], '|', board[1 + i * 3], '|', board[2 + i * 3], '|')
        print('-------------')


def take_input(player_token) :
    valid = False
    while not valid:
        player_answer = input('Куда поставим ' + player_token + '?')
        try:
            player_answer = ???(player_answer)
        except:
            print('Некорректный ввод. Вы уверены, что ввели число?')
            continue
        if 1 <= player_answer <= 9:
            if str(board[player_answer - 1]) not in 'XO':
                board[player_answer - 1] = player_token
                valid = True
            else:
                print('Эта клеточка уже занята')
        else:
            print('Некорректный ввод. Введите число от 1 до 9 чтобы походить.')


def check_win():
    win_coord = ((0, 1, 2), (3, 4, 5), (6, 7, 8), (0, 3, 6), (1, 4, 7), (2, 5, 8), (0, 4, 8), (2, 4, 6))
    for each in win_coord:
        if board[each[0]] == board[each[1]] == board[each[2]]:
            return board[each[0]]
    return False


def main() :
    counter = 0
    win = False
    while not win:
        draw_board()
        if counter % 2 == 0:
            take_input('X')
        else:
            take_input('O')
        counter += 1
        if counter > 4:
            tmp = check_win()
            if tmp:
                print(tmp, 'выиграл!')
                win = True
                break
        if counter == 9:
            print(' Ничья!')
            break
    draw_board()


if __name__ == '__main__':
    board = list(range(1, 10))
    main()";
    private string[] answer;

    void Start()
    {
        InitAll();
        answer = codeAns.Split('\n');
        //первым делом выводим ошибку
        input.text = error;
    }

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll > 0.0f && input.isFocused)
        {
            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.UP);
        }
        else if (scroll < 0.0f && input.isFocused)
        {
            inputSimulator.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.DOWN); 
        }
    }

    void InitAll()
    {
        hero = GameObject.FindGameObjectWithTag("Player");
        canvas = GetComponent<Canvas>();
        canvas.gameObject.SetActive(false);
        input = GetComponentInChildren<InputField>();
        SpriteRenderer[] screens = GetComponentsInChildren<SpriteRenderer>();
        foreach(var scr in screens)
        {
            if (scr.gameObject.name == "ScreenRed")
                screenRed = scr;
            else
                screenGreen = scr;
        }
        screenGreen.enabled = false;
        Button[] buttons = GetComponentsInChildren<Button>();
        foreach(var b in buttons)
        {
            if (b.gameObject.name == "ButNext")
                butNext = b;
            if (b.gameObject.name == "ButExitR")
                butExitR = b;
            if (b.gameObject.name == "ButOK")
            {
                butOK = b;
                butOK.gameObject.SetActive(false);
            }
            if (b.gameObject.name == "ButExitG")
            {
                butExitG = b;
                butExitG.gameObject.SetActive(false);
            }
        }
    }

    public void CalculateScore()
    {
        attempts += 1;
        string[] playerAnswer = Clean(input.text.Split('\n'));
        answer = Clean(answer);
        for (int i = 0; i < playerAnswer.Length; i++)
        {
            try
            {
                if (!(playerAnswer[i] == answer[i]))
                    score--;
            } catch 
            {
                score--;
            }
        }
        if (score < 0)
            score = 0;
        print(score);
        ExitConsole();
    }

    private string[] Clean(string[] array)
    {
        string res = "";
        foreach(var i in array)
        {
            if (!i.Equals(""))
                res += i + "\n";
        }
        return res.Split('\n');
    }

    public void ExitConsole()
    {
        canvas.gameObject.SetActive(false);
        Input.ResetInputAxes();
        hero.SetActive(true);
    }


    public void ChangeScreene()
    {
        input.interactable = true;
        input.text = codeTask;
        butExitG.gameObject.SetActive(true);
        butExitR.gameObject.SetActive(false);
        butNext.gameObject.SetActive(false);
        butOK.gameObject.SetActive(true);
        screenGreen.enabled = true;
        screenRed.enabled = false;
        hero.SetActive(false);
    }
}
