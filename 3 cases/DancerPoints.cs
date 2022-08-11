namespace _3_cases
{
    internal class DancerPoints
    {
        internal string navn; //opret internal string
        internal int points; //opret internal int
        internal DancerPoints(string navn, int points)
        {
            this.navn = navn; //gem navn variable i denne instance
            this.points = points; //gem points variable í denne instance
        }
        public static DancerPoints operator +(DancerPoints first, DancerPoints last) //overload med +
        {
            string navn = $"{first.navn} og {last.navn}"; //sæt færste og sidste danser navn sammen
            int points = first.points + last.points; //tæl points sammen
            DancerPoints total = new DancerPoints(navn, points); //opret total instance med navn og points
            return total;
        }
    }
}
