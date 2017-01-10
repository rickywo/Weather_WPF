
using System.Windows.Input;
using WpfApplication1.Models;
using System;

namespace WpfApplication1.ViewModels
{
    public class WeatherViewModel: ObservableObject
    {
        private WeatherModel _weatherModel;

        public WeatherViewModel()
        {
            _weatherModel = new WeatherModel();
        }

        public float Day1_temp
        {
            get { return get_temp(0); }
        }

        public float Day2_temp
        {
            get { return get_temp(1); }
        }
        public float Day3_temp
        {
            get { return get_temp(2); }
        }
        public float Day4_temp
        {
            get { return get_temp(3); }
        }

        public float Day5_temp
        {
            get { return get_temp(4); }
        }

        public float Day6_temp
        {
            get { return get_temp(5); }
        }

        public float Day7_temp
        {
            get { return get_temp(6); }
        }

        public string Day1_type
        {
            get { return get_type(0); }
        }

        public string Day2_type
        {
            get { return get_type(1); }
        }
        public string Day3_type
        {
            get { return get_type(2); }
        }
        public string Day4_type
        {
            get { return get_type(3); }
        }

        public string Day5_type
        {
            get { return get_type(4); }
        }

        public string Day6_type
        {
            get { return get_type(5); }
        }

        public string Day7_type
        {
            get { return get_type(6); }
        }

        private async void GetForcast()
        {
            await _weatherModel.getForcast();
            LoadValues();
        }

        private void LoadValues()
        {
            for (int i = 1; i < 8; i++)
            {
                OnPropertyChanged("Day" + i + "_temp");
                OnPropertyChanged("Day" + i + "_type");
            }
            
        }

        private float get_temp(int i)
        {
            try
            {
                return _weatherModel.result.Daily.Days[i].MaxTemperature;
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        private string get_type(int i)
        {
            try
            {
                return _weatherModel.result.Daily.Days[i].Icon;
            }
            catch (Exception e)
            {
                return "None";
            }
        }

        public ICommand GetForecastCommand
        {
            get { return new DelegateCommand(GetForcast); }
        }
    }
}
