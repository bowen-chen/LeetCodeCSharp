/*
353 Design Snake Game
easy
Design a Snake game that is played on a device with screen size = width x height. Play the game online if you are not familiar with the game.

The snake is initially positioned at the top left corner (0,0) with length = 1 unit.

You are given a list of food's positions in row-column order. When a snake eats the food, its length and the game's score both increase by 1.

Each food appears one by one on the screen. For example, the second food will not appear until the first food was eaten by the snake.

When a food does appear on the screen, it is guaranteed that it will not appear on a block occupied by the snake.

Example:
Given width = 3, height = 2, and food = [[1,2],[0,1]].

Snake snake = new Snake(width, height, food);

Initially the snake appears at position (0,0) and the food at (1,2).

|S| | |
| | |F|

snake.move("R"); -> Returns 0

| |S| |
| | |F|

snake.move("D"); -> Returns 0

| | | |
| |S|F|

snake.move("R"); -> Returns 1 (Snake eats the first food and right after that, the second food appears at (0,1) )

| |F| |
| |S|S|

snake.move("U"); -> Returns 1

| |F|S|
| | |S|

snake.move("L"); -> Returns 2 (Snake eats the second food)

| |S|S|
| | |S|

snake.move("U"); -> Returns -1 (Game over because snake collides with border)
*/

using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo
{
    public class SnakeGame
    {
        private readonly int _width;
        private readonly int _height;
        private int _score;
        private readonly List<Tuple<int, int>> _food;
        private readonly List<Tuple<int, int>> _pos = new List<Tuple<int, int>>();

        /** Initialize your data structure here.
        @param width - screen width
        @param height - screen height 
        @param food - A list of food positions
        E.g food = [[1,1], [1,0]] means the first food is positioned at [1,1], the second is at [1,0]. */

        public SnakeGame(int width, int height, List<Tuple<int, int>> food)
        {
            _width = width;
            _height = height;
            _food = food;
            _score = 0;
            _pos.Add(Tuple.Create(0, 0));
        }

        /** Moves the snake.
            @param direction - 'U' = Up, 'L' = Left, 'R' = Right, 'D' = Down 
            @return The game's score after the move. Return -1 if game over. 
            Game over when snake crosses the screen boundary or bites its body. */

        public int Move(string direction)
        {
            var head = _pos[0];
            if (direction == "U") head = Tuple.Create(head.Item1 - 1, head.Item2);
            else if (direction == "L") head = Tuple.Create(head.Item1, head.Item2 - 1);
            else if (direction == "R") head = Tuple.Create(head.Item1, head.Item2 + 1);
            else if (direction == "D") head = Tuple.Create(head.Item1 + 1, head.Item2);
            if (_pos.Any(p => p.Item1 == head.Item1 && p.Item2 == head.Item2) ||
                head.Item1 < 0 || head.Item1 >= _height ||
                head.Item2 < 0 || head.Item2 >= _width)
            {
                return -1;
            }

            _pos.Insert(0, head);
            if (_food.Count > 0 &&
                head.Item1 == _food[0].Item1 && head.Item2 == _food[0].Item2)
            {
                _food.RemoveAt(0);
                ++_score;
            }
            else
            {
                _pos.RemoveAt(_pos.Count - 1);
            }

            return _score;
        }
    };
}
