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
using static GMap.NET.MapProviders.StrucRoads.SnappedPoint;

namespace geographical_information_system
{
    public partial class Form1 : Form
    {

         GMapOverlay layer1;
        List<Car> List;


        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            MakeCarList();
            

        }


        private void MakeCarList()
        {
            List = new List<Car>();
            List.Add(new Car("34 AC 01", "Tir", "Bursa", "Istanbul", new PointLatLng(40.16, 28.5)));
            List.Add(new Car("06 GS 197", "Kamyon", "Ankara", "Istanbul", new PointLatLng(39.5, 32.55)));
            List.Add(new Car("41 FB 882", "Ticari", "Ankara", "Kocaeli", new PointLatLng(39.56, 32.60)));
            List.Add(new Car("35 TS 185", "Ticari", "Eskisehir", "Izmir", new PointLatLng(39.75, 30.54)));
            List.Add(new Car("42 BJK 016", "Tir", "Konya", "Istanbul", new PointLatLng(37.88, 32.60)));

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
            layer1 = new GMapOverlay();

            // Bir overlay(katman) oluşturmamız lazım
            // Harita uzerınden goruntulenecek tum componentleri bu katman(overlay) eklememiz gerekmekte
            // GMapOverlay layer1 = new GMapOverlay(); 

            // ilk olarak da yeni oluşturdugumuz katmanı harita nesnemıze eklemelıyız
            Map.Overlays.Add(layer1);

        }

      

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) // formu kapattıktan sonra takılı kalmadan kapatmayı sağlar
        {
            Map.Dispose();
            Application.Exit();
        }

        private void btnshow1_Click(object sender, EventArgs e)
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

            marker.Tag = 101;

            

            
            
            // daha sonra marker(ları) eklemeliyiz
            //dikkat!!
            // markerlerı once eklersek yanlıs yere koyabılır
            layer1.Markers.Add(marker);
            

        }

        private void Map_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            // int markerId = (int)item.Tag;  
            // Console.WriteLine(" id: "+markerId + ", Marker was clicked");
            string selectcarlicenseplate = (string)item.Tag;
            foreach(Car car in List)
            {
                if (selectcarlicenseplate.Equals(car.Carlicenseplate))
                {
                    txtlicense.Text = car.Carlicenseplate;
                    txttype.Text = car.Cartype;
                    txtfrom.Text = car.From;    
                    txtTo.Text = car.To;
                    break;
                }
            }

        } 

        private void btnshow2_Click(object sender, EventArgs e)
        {
            PointLatLng location2 = new PointLatLng(Convert.ToDouble(txtlati2.Text),
                                                                      Convert.ToDouble(txtlong2.Text));

            GMarkerGoogle marker2 = new GMarkerGoogle(location2, GMarkerGoogleType.blue_dot);
            marker2.Tag = 102;
            layer1.Markers.Add(marker2);
        }

        private void btnaddmap_Click(object sender, EventArgs e)
        {
            foreach (Car car in List)
            {
                GMarkerGoogle markertemp = new GMarkerGoogle(car.Location, GMarkerGoogleType.green_dot);
                markertemp.Tag = car.Carlicenseplate;
                markertemp.ToolTipText = car.ToString();
                layer1.Markers.Add(markertemp);
            }
        }
    }
}
