using System;
using System.Collections.Generic;

namespace simulation
{

    public static class Extensions
    {
        public static T[] SubArray<T>(this T[] array, int offset, int length)
        {
            return new List<T>(array)
                        .GetRange(offset, length)
                        .ToArray();
        }

        public static int SubArrayLength<T>(this T[] array, int from)
        {
            int total = 0;
            for(int j = from; j < array.Length; j++)
            {
                total += 1;
            }
            return total;
        }
    }

    public class Input
    { 
        private string[] _inputText;
        private string[] _busCapacity;
        private string[] _boardingTime;
        private string[] _requestRate;
        private string[] _pickupInterval;
        private string[] _maxDelay;
        private string[] _noBuses;
        private string[] _noStops;
        private string[,] _network;
        private string[] _stopTime;

        public Input(string[] InputText)
        {
            _inputText = InputText;

        }

        public string[] BusCapacity
        {
            get {

                return _busCapacity;
            }
            set {
                _busCapacity = value;
            }
        }

        public string[] BoardingTime
        {
            get
            {

                return _boardingTime;
            }
            set
            {
                _boardingTime = value;
            }
        }

        public string[] RequestRate
        {
            get
            {

                return _requestRate;
            }
            set
            {
                _requestRate = value;
            }
        }

        public string[] PickupInterval
        {
            get
            {

                return _pickupInterval;
            }
            set
            {
                _pickupInterval = value;
            }
        }

        public string[] MaxDelay
        {
            get
            {

                return _maxDelay;
            }
            set
            {
                _maxDelay = value;
            }
        }

        public string[] NoBuses
        {
            get
            {

                return _noBuses;
            }
            set
            {
                _noBuses = value;
            }
        }

        public string[] NoStops
        {
            get
            {

                return _noStops;
            }
            set
            {
                _noStops = value;
            }
        }

        public string[,] Network
        {
            get
            {

                return _network;
            }
            set
            {
                _network = value;
            }
        }

        public string[] StopTime
        {
            get
            {

                return _stopTime;
            }
            set
            {
                _stopTime = value;
            }
        }

        public void parseInput()
        {
            int currentLine = 0;
            while (currentLine < _inputText.Length)
            {
                string[] splittedLine = _inputText[currentLine].Split(' ');
                string expVariable = splittedLine[0];
                switch (expVariable)
                {
                    case "busCapacity": 
                    {
                        BusCapacity=this.GetValues(splittedLine, "busCapacity");
                        System.Console.WriteLine("Capacity: " + String.Join(",", BusCapacity));
                        currentLine+=1;

                    }
                    break;
                    case "boardingTime":
                    {
                        BoardingTime = this.GetValues(splittedLine, "boardingTime");
                        System.Console.WriteLine("boardingTime: " + String.Join(",", BoardingTime));
                        currentLine += 1;
                    }
                    break;
                    case "requestRate":
                    {
                        RequestRate = this.GetValues(splittedLine, "requestRate");
                        System.Console.WriteLine("requestRate: " + String.Join(",", RequestRate));
                        currentLine += 1;
                    }
                    break;
                    case "pickupInterval":
                    {
                        PickupInterval = this.GetValues(splittedLine, "pickupInterval");
                        System.Console.WriteLine("pickupInterval: " + String.Join(",", PickupInterval));
                        currentLine += 1;
                    }
                    break;
                    case "maxDelay":
                    {
                        MaxDelay = this.GetValues(splittedLine, "maxDelay");
                        System.Console.WriteLine("maxDelay: " + String.Join(",", MaxDelay));
                        currentLine += 1;
                    }
                    break;
                    case "noBuses":
                    {
                        NoBuses = this.GetValues(splittedLine, "noBuses");
                        System.Console.WriteLine("noBuses: " + String.Join(",", NoBuses));
                        currentLine += 1;
                    }
                    break;
                    case "noStops":
                    {

                        NoStops = this.GetValues(splittedLine, "noStops");
                        System.Console.WriteLine("noStops: " + String.Join(",", NoStops));
                        currentLine += 1;
                    }
                    break;
                    case "map":
                    {
                        currentLine++;
                        int noStops = Convert.ToInt32(_noStops[0]);
                        Network = new string[noStops,noStops];
                        int pos = 0;
                        while (pos <noStops)
                        {
                            string[] lines = _inputText[currentLine+pos].Split(' ');
                            string[] line = getAllNumbers(lines, 0);
                            for (int j=0;j<noStops;j++) {
                                Network[pos, j] = line[j];
                            }
                            pos += 1;
                        }
                        currentLine += pos;
                       for (int j=0;j<noStops; j++)
                       {
                            for(int i = 0; i < noStops; i++)
                            {
                                System.Console.Write( Network[j,i] + " ");
                            }
                            System.Console.WriteLine();
                        }
                    }
                    break;
                    case "stopTime":
                    {
                        StopTime = this.GetValues(splittedLine, "stopTime");
                        System.Console.WriteLine("stopTime: " + String.Join(",", StopTime));
                        currentLine += 1;
                    }
                    break;
                    default:
                    {
                         
                        if(expVariable[0] == '#')
                        {

                            currentLine++;
                        }
                        else
                        {
                            System.Console.WriteLine("" + expVariable);
                            throw new Exception("Unknown variable in line: " + currentLine);
                        }
                    }
                    break;
                }
            }
        }

        private string[] GetValues(string[] splittedLines, string variable)
        {
            string value = splittedLines[1];
            if (value == "experiment")
            {
                return getAllNumbers(splittedLines, 2);
            }
            else if (IsValidInt(value) || IsValidDouble(value))
            {
                String[] values = getAllNumbers(splittedLines, 1);
                if (values.Length > 1)
                {
                    throw new Exception("So many values provided for variable: " + variable);
                }
                return values;
            }
            else
            {
                throw new Exception("Error Parsing " + variable);
            }
        }


        private Boolean IsValidInt(string value)
        {
            if (Int32.TryParse(value, out int j))
            {
                return true;
            }
            return false;
        }

        private Boolean IsValidDouble(string value)
        {
            if(Double.TryParse(value, out double f))
            {
                return true;
            }
            return false;
        }

        private string[] getAllNumbers(string[] lines, int from)
        {
            string numbers = "";
            int totalValidNumber = 0;
            for (int j=from; j< lines.Length;j++)
            {
                if (IsValidInt(lines[j]) || IsValidDouble(lines[j]))
                {
                    numbers += lines[j] + ",";
                    totalValidNumber += 1;
                }
                else if(lines[j]==" ")
                {
                    continue;
                }
                else
                {
                    throw new Exception("Number is invalid" + lines[j]);
                }
            }
            string[] intNumbers = numbers.Split(',');

            return intNumbers.SubArray(0, totalValidNumber);
        }


    }
}
