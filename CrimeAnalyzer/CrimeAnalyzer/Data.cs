namespace CrimeAnalyzer
{
    internal class Data
    {
        public Data(int year, int population, int violentCrime, int murder, int rape, int robbery, int aggravatedAssault, int propertyCrime, int burglary, int theft, int motorVehicleTheft)
        {
            this.year = year;
            this.population = population;
            this.violentCrime = violentCrime;
            this.murder = murder;
            this.rape = rape;
            this.robbery = robbery;
            this.aggravatedAssault = aggravatedAssault;
            this.propertyClaim = propertyCrime;
            this.burglary = burglary;
            this.theft = theft;
            this.motorVehicleTheft = motorVehicleTheft;
        }

        public int year
        {
            get;
            set;
        }

        public int population
        {
            get;
            set;
        }

        public int violentCrime
        {
            get;
            set;
        }

        public int murder
        {
            get;
            set;
        }

        public int rape
        {
            get;
            set;
        }

        public int robbery
        {
            get;
            set;
        }

        public int aggravatedAssault
        {
            get;
            set;
        }

        public int propertyClaim
        {
            get;
            set;
        }

        public int burglary
        {
            get;
            set;
        }

        public int theft
        {
            get;
            set;
        }

        public int motorVehicleTheft
        {
            get;
            set;
        }
    }
}