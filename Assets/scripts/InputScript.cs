using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    private InputField input;
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
    int score = 14; 

    void Start()
    {
        input = GetComponent<InputField>();
        answer = codeAns.Split('\n');
        //выводим код вопроса
        input.text = codeTask;
    }

    void Update()
    {
        HandleUserInput();
    }

    void HandleUserInput()
    {
        if ( (Input.GetKey(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) 
            && Input.GetKeyDown(KeyCode.D))
            //считаем количество правильно заполненных пропусков
            CalculateScore(input.text.Split('\n'));            
    }

    void CalculateScore(string[] a)
    {
        //сравниваваем построчно код пользователя и ответ
        for(int i = 0; i < a.Length; i++)
        {
            if (!(a[i] == answer[i]))
                score--;
        }
        if (score < 0)
            score = 0;
        print(score);
    }
}
