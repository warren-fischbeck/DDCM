using FischbeckEnterprises.Mobile.DND.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FischbeckEnterprises.Mobile.DND
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            FightClubConverter _FCC = new FightClubConverter();
        }
    }
}
