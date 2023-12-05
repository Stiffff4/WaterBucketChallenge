namespace WaterBucketChallenge.Models
{
    public class Bucket
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public int Cap { get; set; }

        public Bucket()
        {

        }

        public Bucket(string name, int value, int cap)
        {
            Name = name;
            Value = value;
            Cap = cap;
        }
    }
}