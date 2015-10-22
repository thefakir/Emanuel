using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ComponentModel;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NavigationDemo
{
    public class NavPanel : Panel, INotifyPropertyChanged
    {
        #region Fields
        private FrameworkElement _visualParent;
        private Size _lastVisualParentSize;
        private Size _max;
        private double _childrenWidth;
        #endregion //Fields

        #region .ctor
        public NavPanel() { }
        #endregion //.ctor

        #region Overrides and Handlers
        protected override Geometry GetLayoutClip(Size layoutSlotSize)
        {
            return null;
        }
        protected override Size MeasureOverride(Size avaluableSize)
        {
            Size max = new Size();

            UIElement _child;

            for(int i=0; i < this.InternalChildren.Count; i++)
            {
                _child = this.InternalChildren[i];
                _child.Measure(avaluableSize);

                max.Width = Math.Max(max.Width,_child.DesiredSize.Width);
                max.Height = Math.Max(max.Height, _child.DesiredSize.Height);
            }

            _max = max;

            if (double.IsInfinity(avaluableSize.Width) || double.IsInfinity(avaluableSize.Height))
            {
                return new Size(MaxWidth * this.InternalChildren.Count, MaxHeight);
            }
            else
            {
                return new Size(avaluableSize.Width * this.InternalChildren.Count, avaluableSize.Height);
            }
        }
        protected override Size ArrangeOverride(Size finalSize)
        {
            UIElement _child;

            if (_visualParent != null) 
            {
                _lastVisualParentSize = _visualParent.RenderSize;
            }
            else
            {
                _lastVisualParentSize = finalSize;
            }

            for(int i=0; i< this.InternalChildren.Count; i++)
            {
                _child =  this.InternalChildren[i];
                Rect rect = new Rect(new Point(_max.Width * i, 0), _max);
                _child.Arrange(rect);
            }
            ChildrenWidth = _max.Width * InternalChildren.Count;

            return new Size(_lastVisualParentSize.Width, _lastVisualParentSize.Height);
        }
        protected override void OnVisualParentChanged(DependencyObject oldParent)
        {
            base.OnVisualParentChanged(oldParent);

            _visualParent = this.VisualParent as FrameworkElement;
        }
        #endregion //Overrides and Handlers

        #region Properties
        public double ChildrenWidth
        {
            get { return _childrenWidth; }
            set
            {
                if (_childrenWidth != value)
                {
                    _childrenWidth = value;
                    OnPropertyChanged("ChildrenWidth");
                }
            }
        }
        #endregion //Properties

        #region INotifyPropertyChanged
        private void OnPropertyChanged(string name)
        {
            try
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex.Message);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion //INotifyPropertyChanged
    }
}
