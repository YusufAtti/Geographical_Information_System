using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
            //Map.MapProvider = GMapProviders.GoogleHybridMap; // başka harita çeşidi
            Map.Position = new GMap.NET.PointLatLng(36.0, 42.0);
            Map.Zoom = 4;
            Map.MinZoom = 3;
            Map.MaxZoom = 23;


        }

      

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) // formu kapattıktan sonra takılı kalmadan kapatmayı sağlar
        {
            Map.Dispose();
            Application.Exit();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            PointLatLng location1 = new PointLatLng(Convert.ToDouble(txtlati.Text),
                                                                        Convert.ToDouble(txtlong.Text));
            GMarkerGoogle marker = new GMarkerGoogle(location1, GMarkerGoogleType.red_dot); //red_dot marker cinslerini beltir
            marker.ToolTipText = "\nLocation 1\nCar\nFrom: Ankara\nTo  Istanbul\n ";
            marker.ToolTip.Fill = Brushes.Black; //araç ipucu (tooltip) görünümünün arka planını siyah renge ayarlıyor
            marker.ToolTip.Foreground = Brushes.White; // siyah zemın uzerıne beyaz yazı yazmasını saglar
            marker.ToolTip.Stroke = Pens.Purple; //araç ipucu (tooltip) kenar çizgisinin rengini siyah olarak ayarlar
            marker.ToolTip.TextPadding = new Size(5, 5); // siyah ekranın boyutunu ayarlar
            marker.ToolTipMode = MarkerTooltipMode.OnMouseOver; // Mouse'i konuma getirince konum bilgisi gösterir--- .Always yaparsak her zaman gösterir



            // Bir overlay(katman) oluşturmamız lazım
            // Harita uzerınden goruntulenecek tum componentleri bu katman(overlay) eklememiz gerekmekte
            GMapOverlay layer1 = new GMapOverlay(); 

            // ilk olarak da yeni oluşturdugumuz katmanı harita nesnemıze eklemelıyız
            Map.Overlays.Add(layer1);
            
            // daha sonra marker(ları) eklemeliyiz
            //dikkat!!
            // markerlerı once eklersek yanlıs yere koyabılır
            layer1.Markers.Add(marker);

        }
    }
}
