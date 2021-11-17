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
        
        void RandomizeDirection()
        {
            var speed = Random.Shared.NextSingle() * 2.5;
            var angle = Random.Shared.NextSingle() * 360;

            var x = (float)(speed * Math.Cos(angle));
            var y = (float)(speed * Math.Sin(angle));

            movement = new Vector2(x, y);

            // Console.WriteLine($"Speed {movement.Length}");
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

            if (Random.Shared.NextSingle() < .02) RandomizeDirection();
        }

        public void MoveTowards(Vector2 vector)
        {
            var newMove = new Vector2(
                vector.X - position.X,
                vector.Y - position.Y
            );

            var scale = newMove.Length;
            movement = newMove / scale * 2.5f;
        }
    }
}