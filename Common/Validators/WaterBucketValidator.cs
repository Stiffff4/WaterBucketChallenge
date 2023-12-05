using WaterBucketChallenge.Interfaces;

namespace WaterBucketChallenge.Commons.Validators
{
    public class WaterBucketValidator : IWaterBucketValidator
    {
        bool solutionExists = true;
        public bool Validate(int x, int y, int z)
        {
            if (!ValuesAreGreaterThanZero(x, y, z)) solutionDoesntExist();
            if (!ZIsLessThanXAndY(x, y, z)) solutionDoesntExist();
            if (!ZIsDivisibleByXAndY(x, y, z)) solutionDoesntExist();

            return solutionExists;
        }

        public void solutionDoesntExist(){
            solutionExists = false;
        }

        public bool ValuesAreGreaterThanZero(int x, int y, int z){
            return x > 0 && y > 0 && z > 0;
        }

        public bool ZIsLessThanXAndY(int x, int y, int z){
            return z < x || z < y;
        }

        public bool ZIsDivisibleByXAndY(int x, int y, int z)
        {
            while (y != 0)
            {
                int temp = y;
                y = x % y;
                x = temp;
            }
            return z % x == 0;
        }
    }
}