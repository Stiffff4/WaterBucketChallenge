using Newtonsoft.Json;
using WaterBucketChallenge.Commons.Structs;

namespace WaterBucketChallenge.Models
{
    public class Step
    {
        public int Number { get; set; }
        public string Action { get; set; }
        public int Value { get; set; }
        public Bucket AffectedBucket { get; set; }
        public Bucket? ToBucket { get; set; }
        public string Description { get; set; }

        public Step() { }
        public Step(int number, string action, int value, Bucket affectedBucket, Bucket? toBucket = null)
        {
            Number = number;
            Action = action;
            Value = value;
            AffectedBucket = CloneObject(affectedBucket);
            if(toBucket != null) ToBucket = CloneObject(toBucket);
            Description = GetDescription(action, affectedBucket, toBucket);
        }

        private static string GetDescription(string action, Bucket affectedBucket, Bucket? toBucket = null)
        {
            string description = string.Empty;

            if (action == StepAction.Fill && toBucket != null) 
                description = $"{affectedBucket.Name}: {affectedBucket.Value}. {toBucket.Name}: {toBucket.Value}.   Filled bucket {affectedBucket.Name}";

            if (action == StepAction.Empty && toBucket != null) 
                description = $"{toBucket.Name}: {toBucket.Value}. {affectedBucket.Name}: {affectedBucket.Value}.   Emptied bucket {affectedBucket.Name}";

            if (action == StepAction.Transfer && toBucket != null) 
                description = $"{affectedBucket.Name}: {affectedBucket.Value}. {toBucket.Name}: {toBucket.Value}.   Transfered from bucket {affectedBucket.Name} to bucket {toBucket.Name}";

            return description;
        }

        private static T CloneObject<T>(T obj)
        {
            var serialized = JsonConvert.SerializeObject(obj);
            return JsonConvert.DeserializeObject<T>(serialized)!;
        }
    }
}