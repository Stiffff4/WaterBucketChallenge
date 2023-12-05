using WaterBucketChallenge.Models;

namespace WaterBucketChallenge.Interfaces
{
    public interface IWaterBucketService
    {
        string ShowSteps(int x, int y, int z);

        List<Step> GetSteps(int x, int y, int z);

        List<Step> Solve(Bucket fromBucket, Bucket toBucket, int desired);

        void Fill(Bucket bucket, Bucket secondBucket, List<Step> steps);

        void Empty(Bucket bucket, Bucket secondBucket, List<Step> steps);

        void Transfer(Bucket fromBucket, Bucket toBucket, int value, List<Step> steps);

    }
}