using System;
using OpenTK;

namespace TO_Lab_4.Unit
{
    public class BodyPerson
    {
        public BodyPerson()
        {
            // Console.WriteLine(position);
            RandomizeDirection();
        }
        

        public Vector2 position { get; set; }
        protected Vector2 movement { get; set; }

        double GetSpeed()
        {
            return Math.Sqrt(movement.X * movement.X + movement.Y * movement.Y);
        }

        void RandomizeDirection()
        {
            var maxX = (float)Math.Sqrt(2.5);
            var newX = Random.Shared.NextSingle() * maxX - maxX / 2;


            var maxY = (float)Math.Sqrt(2.5-maxX);
            var newY = Random.Shared.NextSingle() * maxY - maxY / 2;

            movement = new Vector2(newX, newY);

            // Console.WriteLine($"Speed {GetSpeed()}");
        }

        public double GetDistanceTo(Person person)
        {
            return Math.Sqrt(
                (person.position.X - position.X) * (person.position.X - position.X)
                +
                (person.position.Y - position.Y) * (person.position.Y - position.Y)
            );
        }

        public void Move(float multiplier)
        {
            
            position += movement * multiplier;
            
            if ( Random.Shared.Next(100) < 5) RandomizeDirection();
            
            if (OutOfBound())
            {
                var newMove = new Vector2(
                    Population.Bound /2 - position.X,
                    Population.Bound /2 - position.Y
                );

                var scale = newMove.LengthFast;
                movement = newMove / scale;
            }
        }

        private bool OutOfBound()
        {
            return position.X < 0 || position.X > Population.Bound || position.Y < 0 || position.Y > Population.Bound;
        }
    }
}