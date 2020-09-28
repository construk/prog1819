using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_R912_MezclaColor
{
    class ColorBinding : INotifyPropertyChanged
    {
        byte rojo;
        byte verde;
        byte azul;
        string color;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Color
        {
            get { return "FF" + Rojo.ToString("X2")+ Verde.ToString("X2")+ Azul.ToString("X2"); }
        }
        public ColorBinding()
        {
            Rojo = 0;
            Verde = 0;
            Azul = 0;   
        }
        public ColorBinding(byte rojo,byte verde,byte azul)
        {
            Rojo = rojo;
            Verde = verde;
            Azul = azul;
        }
        public byte Rojo
        {
            get { return rojo; }
            set
            {
                rojo = value;
                OnPropertyChanged();
            }
        }
        public byte Verde
        {
            get { return verde; }
            set
            {
                verde = value;
                OnPropertyChanged();
            }
        }
        public byte Azul
        {
            get { return azul; }
            set
            {
                azul = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

    }
}
