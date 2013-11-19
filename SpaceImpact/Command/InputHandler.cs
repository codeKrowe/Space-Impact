﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SpaceImpact
{
    public class InputHandler
    {
        private ShipHull playerShip;
        private Command moveRight;
        private Command moveLeft;
        private Command moveUp;
        private Command moveDown;

        GamePadState gamePadState;
        I_InputDevice input;

        public InputHandler(ShipHull player)
        {
            playerShip = player;
            moveRight = new MoveRightCommand(playerShip);
            moveLeft = new MoveLeftCommand(playerShip);
            moveUp = new MoveUpCommand(playerShip);
            moveDown = new MoveDownCommand(playerShip);

            gamePadState = GamePad.GetState(PlayerIndex.One);

            if (gamePadState.IsConnected)
                input = new ControllerInput();
            else
                input = new KeyboardInput();
        }

        public void HandleInput()
        {
            if (input.Left())
            {
                Console.WriteLine("Left key pressed");
                moveLeft.Execute();
            }
            if (input.Right())
            {
                Console.WriteLine("Right key pressed");
                moveRight.Execute();
            }
            if (input.Up())
            {
                Console.WriteLine("Up key pressed");
                moveUp.Execute();
            }
            if (input.Down())
            {
                Console.WriteLine("Down key pressed");
                moveDown.Execute();
            }
        }
    
        public void Update(GameTime gameTime)
        {
            HandleInput();
            input.Update();
        }
    }
}
