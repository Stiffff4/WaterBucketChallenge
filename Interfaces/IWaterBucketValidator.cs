namespace WaterBucketChallenge.Interfaces
{
    public interface IWaterBucketValidator
    {
        public bool Validate(int x, int y, int z);
        public bool ValuesAreGreaterThanZero(int x, int y, int z);
        public bool ZIsLessThanXAndY(int x, int y, int z);
        public bool ZIsDivisibleByXAndY(int x, int y, int z);
    }
}