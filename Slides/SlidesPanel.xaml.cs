using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Slides
{
    public partial class SlidesPanel : UserControl
    {
        public SlidesPanel()
        {
            InitializeComponent();

            States = VisualStateManager.GetVisualStateGroups(slides)
                .Cast<VisualStateGroup>()
                .First()
                .States.Cast<VisualState>()
                .Select(vs => vs.Name)
                .ToArray();
        }

        public string[] States { get; }
    }
}