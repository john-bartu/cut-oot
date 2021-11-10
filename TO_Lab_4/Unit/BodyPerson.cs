using System;
using OpenTK;

namespace TO_Lab_4.Unit
{
    public class BodyPerson
    {
        public BodyPerson()
        {
            position = RandomStartPosition();
            Console.WriteLine(position);
            RandomizeDirection();
        }

        private Vector2 RandomStartPosition()
        {
            int number = new Random().Next(5);
            Console.WriteLine(number);
            switch (number)
            {
                case 0:
                    return new Vector2(0, new Random().NextSingle() * Population.Bound);
                case 1:
                    return new Vector2(Population.Bound, new Random().NextSingle() * Population.Bound);
                case 2:
                    return new Vector2(new Random().NextSingle() * Population.Bound, Population.Bound);
                case 4:
                    return new Vector2(new Random().NextSingle() * Population.Bound, 0);
                default:
                    return new Vector2();
            }
        }

        public Vector2 position { get; set; }
        private Vector2 movement { get; set; }

        double GetSpeed()
        {
            return Math.Sqrt(movement.X * movement.X + movement.Y * movement.Y);
        }

        void RandomizeDirection()
        {
            var random = new Random();
            var maxX = (float)Math.Sqrt(2.5);
            var newX = random.NextSingle() * maxX - maxX / 2;


            var maxY = (float)Math.Sqrt(2.5);
            var newY = random.NextSingle() * maxY - maxY / 2;

            movement = new Vector2(newX, newY);

            // Console.WriteLine($"Speed {GetSpeed()}");
        }

        double GetDistanceTo(Person person)
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
            if (new Random().Next(100) < 1) RandomizeDirection();
            if (OutOfBound())
            {
                var newMove = new Vector2(
                    250 - position.X,
                    250 - position.Y
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