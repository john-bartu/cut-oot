using System;
using OpenTK;

namespace TO_Lab_4.Unit
{
    public class BodyPerson
    {
        protected BodyPerson()
        {
            RandomizeMovement();
        }

        public Vector2 Position { get; set; }
        protected Vector2 Movement { get; set; }

        void RandomizeMovement()
        {
            var speed = Random.Shared.NextSingle() * 2.5;
            var angle = Random.Shared.NextSingle() * 360;
            var x = (float)(speed * Math.Cos(angle));
            var y = (float)(speed * Math.Sin(angle));
            Movement = new Vector2(x, y);
        }

        public double GetDistanceTo(Person person)
        {
            
            return Math.Sqrt(
                (person.Position.X - Position.X) * (person.Position.X - Position.X)
                +
                (person.Position.Y - Position.Y) * (person.Position.Y - Position.Y)
            );
        }

        public double GetDistanceTo2(Person person)
        {
            
            return 
                (person.Position.X - Position.X) * (person.Position.X - Position.X)
                +
                (person.Position.Y - Position.Y) * (person.Position.Y - Position.Y)
            ;
        }
        
        public void Move(float multiplier)
        {
            Position += Movement * multiplier;

            if (Random.Shared.NextSingle() < .02) RandomizeMovement();
        }

        public void MoveTowards(Vector2 vector)
        {
            var newMove = new Vector2(
                vector.X - Position.X,
                vector.Y - Position.Y
            );

            var scale = newMove.Length;
            Movement = newMove / scale * 2.5f;
        }
    }
}