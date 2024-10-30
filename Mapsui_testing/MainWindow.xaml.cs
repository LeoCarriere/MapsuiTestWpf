
using Mapsui;
using Mapsui.Nts.Providers.Shapefile;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace Mapsui_testing {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            MadrauditMapControl.Map = GetMap();
        }

        private Map GetMap() {
            var map = new Map();
            /* Get ShapeFiles */
            var filesPaths = Directory.GetFiles( Directory.GetParent( Environment.CurrentDirectory ).Parent.Parent.FullName + @"\Maps",  "*.shp" );
            /* Add a layer for each ShapeFile */
            foreach( string shapeFilePath in filesPaths ) {
                /* Set data source */
                ShapeFile shpSource = new ShapeFile( shapeFilePath );
                /* Apply basic styles */
                Mapsui.Layers.Layer layer = new Mapsui.Layers.Layer() {
                    DataSource = shpSource,
                    Style = new Mapsui.Styles.VectorStyle {
                        Fill = new Mapsui.Styles.Brush( Mapsui.Styles.Color.FromArgb( 128, 0 , 255 , 0 ) ) ,
                        Line = new Mapsui.Styles.Pen( Mapsui.Styles.Color.FromString("#0969da") , 4 ){PenStrokeCap = Mapsui.Styles.PenStrokeCap.Round, StrokeJoin = Mapsui.Styles.StrokeJoin.Round}
                    }
                };
                /* Add the new layer */
                map.Layers.Add( layer );
            }
            return map;
        }

    }
}