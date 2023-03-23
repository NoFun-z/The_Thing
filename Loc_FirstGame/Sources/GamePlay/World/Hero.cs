using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loc_FirstGame
{
    public class Hero : Basic2D
    {
        public float speed;
        public float sprintSpeed;
        public bool isFacingRight = true;

        // Animation properties
        private int animationIndex = 0;
        private float animationTimer = 0f;
        private const float animationDelay = 0.2f; // Time between animation frames
        private Texture2D[] animationFrames = new Texture2D[3]; // Array of animation frames

        public Hero(string PATH, Vector2 POS, Vector2 DIMS) : base(PATH, POS, DIMS)
        {
            speed = 1.0f;
            sprintSpeed = 3.2F;

            // Load animation frames
            animationFrames[0] = Globals.content.Load<Texture2D>("idle1");
            animationFrames[1] = Globals.content.Load<Texture2D>("idle2");
            animationFrames[2] = Globals.content.Load<Texture2D>("idle3");
        }

        public override void Update()
        {
            // Update animation
            if (speed == 0f)
            {
                animationTimer += Globals.DeltaTime; // Increment animation timer

                if (animationTimer >= animationDelay)
                {
                    animationIndex++; // Switch to next animation frame
                    if (animationIndex >= animationFrames.Length) // Loop back to first frame
                    {
                        animationIndex = 0;
                    }

                    animationTimer = 0f; // Reset animation timer
                }
            }
            else
            {
                animationIndex = 0; // Reset animation frame when moving
            }

            if (Globals.keyboard.GetPress("A"))
            {
                pos = new Vector2(pos.X - speed, pos.Y);
                isFacingRight = false;
            }
            if (Globals.keyboard.GetPress("A") && Globals.keyboard.GetPress("Space"))
            {
                pos = new Vector2(pos.X - sprintSpeed, pos.Y);
                isFacingRight = false;
            }
            if (Globals.keyboard.GetPress("D"))
            {
                pos = new Vector2(pos.X + speed, pos.Y);
                isFacingRight = true;
            }
            if (Globals.keyboard.GetPress("D") && Globals.keyboard.GetPress("Space"))
            {
                pos = new Vector2(pos.X + sprintSpeed, pos.Y);
                isFacingRight = true;
            }
            if (Globals.keyboard.GetPress("W"))
            {
                pos = new Vector2(pos.X, pos.Y - speed);
            }
            if (Globals.keyboard.GetPress("W") && Globals.keyboard.GetPress("Space"))
            {
                pos = new Vector2(pos.X, pos.Y - sprintSpeed);
            }
            if (Globals.keyboard.GetPress("S"))
            {
                pos = new Vector2(pos.X, pos.Y + speed);
            }
            if (Globals.keyboard.GetPress("S") && Globals.keyboard.GetPress("Space"))
            {
                pos = new Vector2(pos.X, pos.Y + sprintSpeed);
            }

            float mouseX = Globals.mouse.newMousePos.X;
            if (mouseX > pos.X)
            {
                isFacingRight = true;
            }
            else
            {
                isFacingRight = false;
            }

            //rot = Globals.RotateTowards(pos, new Vector2(Globals.mouse.newMousePos.X, Globals.mouse.newMousePos.Y));

            base.Update();
        }

        public override void Draw(Vector2 OFFSET)
        {
            Vector2 origin = new Vector2(myModel.Width / 2, myModel.Height / 2);
            SpriteEffects spriteEffects = !isFacingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            base.Draw(OFFSET, origin, spriteEffects);
        }
    }
}
