using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace NavigationDemo
{
    public class NavDecorator : Decorator
    {
        #region Fields
        private CompositionTargetRenderingListener m_listener = new CompositionTargetRenderingListener();
        private NavPanel m_panel;
        private TranslateTransform m_transform = new TranslateTransform();
        
        private RepeatButton _btnLeft, _btnRight;

        //----------------------
        private double _x0, _x1, _L, _S, _dl;
        private double _O = 0.0;
        //----------------------

        private double m_velocity;
        private double m_percentOffset;
        private double offset = 0.0;
        private const double c_diff = .00001;
        #endregion //Fields

        #region .ctor
        public NavDecorator()
        {
            m_listener.StartListening();
            m_listener.Rendering += new EventHandler(m_listener_Rendering);

            DispatcherOperationCallback method = null;

            method = delegate(object unused)
            {
                (this.Child as NavPanel).PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(NavPanelPropertyChanged);
                return null;
            };
            this.Dispatcher.BeginInvoke(DispatcherPriority.Send, method, null);
        }
        #endregion //.ctor

        #region Handlers
        protected override Size MeasureOverride(Size constraint)
        {
            if (_btnLeft == null) _btnLeft = this.FindName("PART_Left") as RepeatButton;
            if (_btnRight == null) _btnRight = this.FindName("PART_Right") as RepeatButton;

            
            _S = this.ActualWidth;
            if (_L > _S)
            {
                _x1 = _S;
                _x0 = _S - _L;
                m_transform.X = _x0;
            }
            else
            {
                _x0 = _O;
                _x1 = _L;
                m_transform.X = _x0;
            }
            offset = 0.0;
            UpdateState();

            return base.MeasureOverride(constraint);
        }
        protected override Size ArrangeOverride(Size arrangeSize)
        {
            UIElement child = this.Child;
            if (child != null)
            {
                Rect rect = new Rect(new Point(0, 0), arrangeSize);
                child.Arrange(rect);
            }

            return arrangeSize;
        }
        private void NavPanelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            NavPanel m_panel = this.Child as NavPanel;

            if (m_panel == null)
                return;

            switch (e.PropertyName)
            {
                case "ChildrenWidth":

                    _L = m_panel.ChildrenWidth;
                    _dl = _L / m_panel.Children.Count;

                    if (_L > _S)
                    {
                        _x1 = _S;
                        _x0 = _S - _L;
                        m_transform.X = _x0;
                    }
                    else
                    {
                        _x0 = _O;
                        _x1 = _L;
                        m_transform.X = _x0;
                    }
                    offset = 0.0;
                    UpdateState();
                    break;
                default: break;
            }
        }
        private void m_listener_Rendering(object sender, EventArgs e)
        {
            if (this.Child != m_panel)
            {
                m_panel = (NavPanel)this.Child;
                m_panel.RenderTransform = m_transform;
            }

            if (m_panel != null)
            {
                bool stopListening = !WpfUtil.Animate(
                    m_percentOffset, m_velocity, offset,
                    .05, .3, .1, c_diff, c_diff,
                    out m_percentOffset, out m_velocity);

                double _dx = m_percentOffset * _dl;

                _x0 = _dx;
                _x1 = _x0 + _L;

                if (stopListening)
                {
                    m_listener.StopListening();
                    UpdateState();
                }

                m_transform.X = _dx;
            }
        }
        #endregion //Handlers

        #region Methods
        public void CanLeft(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public void MoveLeft(object sender, ExecutedRoutedEventArgs args)
        {
            offset -= 1;
            m_listener.StartListening();
        }
        public void CanRight(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        public void MoveRight(object sender, ExecutedRoutedEventArgs args)
        {
            offset += 1;
            m_listener.StartListening();
        }
        private void UpdateState()
        {
            if (_L < _S)
            {
                _btnRight.IsEnabled = _btnLeft.IsEnabled = false;
            }
            else
            {
                if (_x0 < _O)
                    _btnRight.IsEnabled = true;
                else
                    _btnRight.IsEnabled = false;

                if (_x1 > _S)
                    _btnLeft.IsEnabled = true;
                else
                    _btnLeft.IsEnabled = false;
            }
        }
        #endregion //Methods
    }
}
