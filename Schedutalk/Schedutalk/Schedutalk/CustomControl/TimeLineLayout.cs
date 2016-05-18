using Schedutalk.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Schedutalk.CustomControl
{
    class TimeLineLayout : Layout<Xamarin.Forms.View>
    {
        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(TimeLineLayout), null, propertyChanged: OnItemsSourcePropertyChanged);
        
        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var items = newValue as ObservableCollection<MEvent>;
            
            var layout = bindable as TimeLineLayout;

            if (layout != null)
                layout.OnItemsSourceChanged((IEnumerable)oldValue, (IEnumerable)newValue);
        }

        private void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            // Remove handler for oldValue.CollectionChanged
            var oldValueINotifyCollectionChanged = oldValue as INotifyCollectionChanged;

            if (null != oldValueINotifyCollectionChanged)
            {
                oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(INotifyCollectionChanged);
            }
            // Add handler for newValue.CollectionChanged (if possible)
            var newValueINotifyCollectionChanged = newValue as INotifyCollectionChanged;
            if (null != newValueINotifyCollectionChanged)
            {
                if (this.Children.Count < ItemsSource.Count) //Ensure all items added be4 binding are included!
                {
                    foreach (var item in ItemsSource)
                    {
                        var view = (Xamarin.Forms.View)ItemTemplate.CreateContent();
                        var bindableObject = view as BindableObject;
                        if (bindableObject != null)
                            bindableObject.BindingContext = item;
                        this.Children.Add(view);
                    }
                }
                else
                {
                    this.Children.Clear();
                }
                newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(INotifyCollectionChanged);
            }
        }

        private void INotifyCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {

            var view = (Xamarin.Forms.View)ItemTemplate.CreateContent();
            var bindableObject = view as BindableObject;
            if (bindableObject != null && ItemsSource.Count > 0)
                bindableObject.BindingContext = ItemsSource[ItemsSource.Count - 1];
            this.Children.Add(view);
        }

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public DataTemplate ItemTemplate { get; set; }

        public static readonly BindableProperty SpacingProperty = BindableProperty.Create(nameof(Spacing), typeof(double), typeof(TimeLineLayout), 0.0, propertyChanged: OnSpacingChanged);

        private static void OnSpacingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //Each time spacing changes the measurement will be validated
            var self = (TimeLineLayout)bindable;
            self.InvalidateMeasure();
        }

        protected override SizeRequest OnSizeRequest(double widthConstraint, double heightConstraint)
        {
            var layout = ComputeNaiveLayout(widthConstraint, heightConstraint);
            var width = layout.Max(row => row.Width);
            var last = layout[layout.Count - 1];
            if (last.Count == 0) return new SizeRequest(new Size(0,0));

            var height = last[last.Count - 1].Bottom;

            return new SizeRequest(new Size(width, height));
        }

        private IEnumerable<Rectangle> ComputeLayout(double widthConstraint, double heightConstraint)
        {
            var layout = ComputeNaiveLayout(widthConstraint, heightConstraint);

            return layout.SelectMany(s => s);
        }

        private List<Row> ComputeNaiveLayout(double widthConstraint, double heightConstraint)
        {
            //Offseting
            double timePositions = 24 * 60;

            var result = new List<Row>();
            var row = new Row();
            result.Add(row);

            var spacing = Spacing;
            
            double yScale = 2;

            if (ItemsSource == null) throw new Exception("Make sure binding is working!");
            IEnumerator mEvents = ItemsSource.GetEnumerator();


            for (int i = 0; i < Children.Count; i++)
            {
                Xamarin.Forms.View child = Children[i];
                var request = child.GetSizeRequest(double.PositiveInfinity, double.PositiveInfinity);

                mEvents.MoveNext();
                
                MEvent mEvent = mEvents.Current as MEvent;
                MDate dTS = mEvent.StartDate;
                MDate dTE = mEvent.EndDate;

                double topY = (double)dTS.Hour*60 + (double)dTS.Minute;
                double botY = (double)dTE.Hour*60 + (double)dTE.Minute;
                row.Add(new Rectangle(0, topY*yScale, request.Request.Width, (botY - topY)*yScale));
                row.Width = request.Request.Width + spacing;
                row.Height = Math.Max(row.Height, timePositions * yScale);
            }

            return result;
        }

        protected override void LayoutChildren(double x, double y, double width, double height)
        {
            var layout = ComputeLayout(width, height);
            int i = 0;
            
            foreach (var region in layout)
            {
                var child = Children[i];
                i++;
                LayoutChildIntoBoundingRegion(child, region);
            }
        }

        class Row : List<Rectangle>
        {
            public double Width { get; set; }
            public double Height { get; set; }
        }


    }
}
