namespace TestTdd
{
    internal class SimpleDataPure
    {
        internal int energyCostPerAdd;

        public int EnergyCostPerAdd
        {
            get { return energyCostPerAdd; }
        }
    }

    internal class SimpleData : SimpleDataPure
    {
        public SimpleData(string filePath)
        {
            // Fake read and fill data
            energyCostPerAdd = 2;
        }
    }
}