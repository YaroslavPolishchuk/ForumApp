using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Patterns.InterfaceSegregation
{
    public interface IShootable
    {
        public void Shoot();
    }

    public interface IClimbable
    {
        public void Climb();
    }

    public interface ISwimmable
    {
        public void Swim();
    }

    public class Cowboy : IShootable, ISwimmable, IClimbable
    {
        public void Climb()
        {
            throw new NotImplementedException();
        }

        public void Shoot()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }

    public class Doctor : IShootable
    {
        public void Shoot()
        {
            throw new NotImplementedException();
        }
    }

    public class FitnessGirl : ISwimmable, IClimbable
    {
        public void Climb()
        {
            throw new NotImplementedException();
        }

        public void Swim()
        {
            throw new NotImplementedException();
        }
    }
}
