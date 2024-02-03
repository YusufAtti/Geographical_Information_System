using GMap.NET.MapProviders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace geographical_information_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap()
        {
            Map.DragButton = MouseButtons.Left; // key change to zoom in
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Position = new GMap.NET.PointLatLng(36.0, 42.0);
            Map.Zoom = 4;
            Map.MinZoom = 3;
            Map.MaxZoom = 23;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
