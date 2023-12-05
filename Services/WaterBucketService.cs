using WaterBucketChallenge.Commons.Structs;
using WaterBucketChallenge.Models;
using WaterBucketChallenge.Interfaces;
using Newtonsoft.Json;

namespace WaterBucketChallenge.Services
{
    public class WaterBucketService(IWaterBucketValidator waterBucketValditator) : IWaterBucketService
    {
        private readonly IWaterBucketValidator _waterBucketValditator = waterBucketValditator;

        public virtual string ShowSteps(int x, int y, int z)
        {
            List<Step> solution = GetSteps(x, y, z);
            if (solution.Count == 0) return "No hay solucion";
            IEnumerable<string> stepsDescription = solution.Select(x => x.Description);

            return JsonConvert.SerializeObject(stepsDescription, Formatting.Indented);
        }

        public virtual List<Step> GetSteps(int x, int y, int z)
        {
            if (!_waterBucketValditator.Validate(x, y, z)) return [];

            Bucket bucketX = new("X", 0, x);
            Bucket bucketY = new("Y", 0, y);

            List<Step> solution1 = Solve(bucketY, bucketX, z);
            List<Step> solution2 = Solve(bucketX, bucketY, z);

            return solution1.Count < solution2.Count ? solution1 : solution2;

        }

        public virtual List<Step> Solve(Bucket fromBucket, Bucket toBucket, int target)
        {
            List<Step> steps = [];

            Fill(fromBucket, toBucket, steps);
           
            while (fromBucket.Value != target && toBucket.Value != target)
            {
                int transferValue = Math.Min(fromBucket.Value, toBucket.Cap - toBucket.Value);

                Transfer(fromBucket, toBucket, transferValue, steps);

                if (fromBucket.Value == target || toBucket.Value == target) break;

                if (fromBucket.Value == 0) Fill(fromBucket, toBucket, steps);

                if (toBucket.Value == toBucket.Cap) Empty(toBucket, fromBucket, steps);
                
            }
            fromBucket.Value = 0;
            toBucket.Value = 0;
            return steps;
        }

        public virtual void Fill(Bucket bucket, Bucket secondBucket, List<Step> steps)
        {
            bucket.Value = bucket.Cap;
            steps.Add(new Step(steps.Count + 1, StepAction.Fill, bucket.Cap, bucket, secondBucket));
        }

        public virtual void Empty(Bucket bucket, Bucket secondBucket, List<Step> steps)
        {
            int currentVal = bucket.Value;
            bucket.Value = 0;
            steps.Add(new Step(steps.Count + 1, StepAction.Empty, currentVal, bucket, secondBucket));
        }

        public virtual void Transfer(Bucket fromBucket, Bucket toBucket, int value, List<Step> steps)
        {
            toBucket.Value += value;
            fromBucket.Value -= value;

            steps.Add(new Step(steps.Count + 1, StepAction.Transfer, value, fromBucket, toBucket));
        }
    }
}