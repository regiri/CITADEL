using UnityEngine;
using UnityEngine.UI;

public class InputScript : MonoBehaviour
{
    private InputField input;
    private string codeTask = @"C#
using System;

???????? x_and_o_robot_program
{
    class Program
    {
        public char[] board = ??? char[9]
        {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public char CheckWin() {
            int[,] win_cord = new int[8, 3] {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},
                {???????},
                {0, 4, 8},
                {2, 5, 8},
                {2, 4, 6} };
            for (int i = 0; i < 8; i++) {
                if (board[win_cord[i, 0]] == board[win_cord[i, 1]] &&
                    board[win_cord[i, 2]] == board[win_cord[i, 0]]) {
                    ?????? board[win_cord[i, 0]];
                }
            }
            return '0';
        }
        public void DrawBoard() {
            Console.WriteLine('-------');
            for (int i = 0; i< 3; i++) {
                Console.Write('|' + board[i * 3]);
                Console.Write('|' + board[i * 3 + 1]);
                Console.Write('|' + board[i * 3 + 2] + '|');
                Console.WriteLine('');
            }
Console.WriteLine('-------');
        }
        public void TakeInput(???? player_place) {
    bool valid = false;
    ??? player_answer;
    while (!valid) {
        Console.WriteLine('Куда поставим ' + player_place + '?');
        try {
            player_answer = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException) {
            Console.WriteLine('Некорректный ввод. Вы уверены, что ввели число?');
            continue;
        }
        if (player_answer >= 1 && player_answer <= 9) {
            if (board[player_answer - 1] != 'X' &&
                board[player_answer - 1] != 'O') {
                board[player_answer - 1] = player_place;
                valid = true;
            }
            else {
                ???????.WriteLine('Эта клеточка уже занята');
            }
        }
        else {
            Console.WriteLine('Некорректный ввод. Введите число от 1 до 9 чтобы сходить.');
        }
    }
}
static void Main(string[] args) {
    bool win = false;
    int counter = 0;
    Program x_or_o = new Program();
    while (!win) {
        x_or_o.DrawBoard();
        if (counter % 2 == 0) {
            x_or_o.TakeInput('X');
        }
        else {
            ??????.TakeInput('O');
        }
        counter += 1;
        if (counter == 9) { Console.WriteLine('Ничья!'); }
        else if (counter > 4) {
            char tmp = x_or_o.CheckWin();
            if (tmp != '0') {
                Console.WriteLine(tmp + ' выйграл!');
                win = true;
            }
        }
    }
    x_or_o.DrawBoard();
}
    }
}";
    private string codeAns = @"C#
using System;

namespace x_and_o_robot_program
{
    class Program
    {
        public char[] board = new char[9]
        {'1', '2', '3', '4', '5', '6', '7', '8', '9'};
        public char CheckWin() {
            int[,] win_cord = new int[8, 3] {
                {0, 1, 2},
                {3, 4, 5},
                {6, 7, 8},
                {0, 3, 6},
                {1, 4, 7},
                {0, 4, 8},
                {2, 5, 8},
                {2, 4, 6} };
            for (int i = 0; i < 8; i++) {
                if (board[win_cord[i, 0]] == board[win_cord[i, 1]] &&
                    board[win_cord[i, 2]] == board[win_cord[i, 0]]) {
                    return board[win_cord[i, 0]];
                }
            }
            return '0';
        }
        public void DrawBoard() {
            Console.WriteLine('-------');
            for (int i = 0; i< 3; i++) {
                Console.Write('|' + board[i * 3]);
                Console.Write('|' + board[i * 3 + 1]);
                Console.Write('|' + board[i * 3 + 2] + '|');
                Console.WriteLine('');
            }
Console.WriteLine('-------');
        }
        public void TakeInput(char player_place) {
    bool valid = false;
    int player_answer;
    while (!valid) {
        Console.WriteLine('Куда поставим ' + player_place + '?');
        try {
            player_answer = Convert.ToInt32(Console.ReadLine());
        }
        catch (FormatException) {
            Console.WriteLine('Некорректный ввод. Вы уверены, что ввели число?');
            continue;
        }
        if (player_answer >= 1 && player_answer <= 9) {
            if (board[player_answer - 1] != 'X' &&
                board[player_answer - 1] != 'O') {
                board[player_answer - 1] = player_place;
                valid = true;
            }
            else {
                Console.WriteLine('Эта клеточка уже занята');
            }
        }
        else {
            Console.WriteLine('Некорректный ввод. Введите число от 1 до 9 чтобы сходить.');
        }
    }
}
static void Main(string[] args) {
    bool win = false;
    int counter = 0;
    Program x_or_o = new Program();
    while (!win) {
        x_or_o.DrawBoard();
        if (counter % 2 == 0) {
            x_or_o.TakeInput('X');
        }
        else {
            x_or_o.TakeInput('O');
        }
        counter += 1;
        if (counter == 9) { Console.WriteLine('Ничья!'); }
        else if (counter > 4) {
            char tmp = x_or_o.CheckWin();
            if (tmp != '0') {
                Console.WriteLine(tmp + ' выйграл!');
                win = true;
            }
        }
    }
    x_or_o.DrawBoard();
}
    }
}";
    private string[] answer;
    int score = 8; 

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
