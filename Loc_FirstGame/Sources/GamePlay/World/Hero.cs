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
        private const int NumFrames = 4;

        private Texture2D spriteSheet;
        private Rectangle[] rectangles;
        private int currentFrame;
        private int frameCount;
        private int frameDelay = 18; // Increase this value to slow down the animation

        public float speed;
        public float sprintSpeed;
        public bool isFacingRight = true;
        public bool isMoving;

        public Hero(Texture2D spriteSheet, Vector2 POS, Vector2 DIMS, Rectangle[] rectangles) : base(spriteSheet, POS, DIMS, rectangles)
        {
            this.spriteSheet = spriteSheet;
            speed = 1.0f;
            sprintSpeed = 3.2F;
            this.rectangles = rectangles;
        }

        public override void Update()
        {
            base.Update();

            if (Globals.keyboard.GetPress("A") || Globals.keyboard.GetPress("D") || Globals.keyboard.GetPress("W") || Globals.keyboard.GetPress("S"))
            {
                isMoving = true;
            }
            else
            {
                isMoving = false;
            }

            if (!isMoving)
            {
                frameCount++;
                if (frameCount > frameDelay)
                {
                    currentFrame++;
                    if (currentFrame >= NumFrames)
                    {
                        currentFrame = 0; // reset to first frame
                    }
                    frameCount = 0;
                }
            }
            else
            {
                currentFrame = 0;
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
        }

        public override void Draw(Vector2 OFFSET, Rectangle? sourceRectangle, SpriteEffects spriteEffects)
        {
            spriteEffects = isFacingRight ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            if (myModel != null)
            {
                Rectangle destinationRectangle = new Rectangle(
                    Convert.ToInt32(pos.X + OFFSET.X),
                    Convert.ToInt32(pos.Y + OFFSET.Y),
                    Convert.ToInt32(dims.X),
                    Convert.ToInt32(dims.Y));

                sourceRectangle = rectangles[currentFrame];

                base.Draw(OFFSET, sourceRectangle, spriteEffects);
            }
        }
    }
}
