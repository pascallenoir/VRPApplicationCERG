﻿using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace VRPApplicationCERG.Controls
{
    #region Delegates

    /// <summary>
    /// The OnTabClickEventHandler
    /// </summary>
    /// <param name="sender">The sender<see cref="object"/></param>
    /// <param name="args">The args<see cref="OnTabClickedEventArgs"/></param>
    public delegate void OnTabClickEventHandler(object sender, OnTabClickedEventArgs args);

    #endregion

    /// <summary>
    /// Defines the <see cref="XFTabControl" />.
    /// </summary>
    public class XFTabControl : Frame
    {
        #region PRIVATE_VARIABLES

        /// <summary>
        /// Defines the SelectedIndexProperty.
        /// </summary>
        public static readonly BindableProperty SelectedIndexProperty = BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(XFTabControl), 0, BindingMode.TwoWay, propertyChanged: IndexChanged);

        /// <summary>
        /// Defines the TabbedPagesProperty.
        /// </summary>
        public static BindableProperty TabbedPagesProperty = BindableProperty.Create(nameof(XFTabPages), typeof(ObservableCollection<XFTabPage>), typeof(XFTabControl), null, BindingMode.TwoWay);

        /// <summary>
        /// Defines the m_Parent.
        /// </summary>
        internal Grid m_Parent;

        /// <summary>
        /// Defines the SelectedPage.
        /// </summary>
        internal XFTabPage SelectedPage;

        /// <summary>
        /// Swipe start and end position..
        /// </summary>
        private double _SwipeStartX = 0, _SwipeStartY = 0;

        /// <summary>
        /// Defines the m_Header.
        /// </summary>
        private Grid m_Header;

        /// <summary>
        /// Defines the m_headerColor.
        /// </summary>
        private Color m_headerColor;

        /// <summary>
        /// Defines the m_Selection.
        /// </summary>
        private Grid m_Selection;

        /// <summary>
        /// Gets or sets the XFTabBody.
        /// </summary>
        internal Grid XFTabBody { get; set; }

        #endregion

        #region PUBLIC_PPTY

        /// <summary>
        /// Gets or sets the HeaderColor.
        /// </summary>
        public Color HeaderColor
        {
            get => m_headerColor;
            set
            {
                m_headerColor = value;
                m_Header.BackgroundColor = value;
                m_Selection.BackgroundColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the HeaderHeight.
        /// </summary>
        public int HeaderHeight { get; set; } = 35;

        /// <summary>
        /// Gets or sets the HeaderTextColor.
        /// </summary>
        public Color HeaderTextColor { get; set; }

        /// <summary>
        /// Gets or sets the Position.
        /// </summary>
        public Position Position { get; set; }

        /// <summary>
        /// Gets or sets the SelectedIndex.
        /// </summary>
        public int SelectedIndex { get => (int)GetValue(SelectedIndexProperty); set => SetValue(SelectedIndexProperty, value); }

        /// <summary>
        /// Gets or sets the SelectionColor.
        /// </summary>
        public Color SelectionColor { get; set; } = Color.FromRgb(139, 140, 196);

        /// <summary>
        /// Gets or sets the SelectorHeight.
        /// </summary>
        public int SelectorHeight { get; set; } = 1;

        /// <summary>
        /// Gets or sets the XFTabPages.
        /// </summary>
        public ObservableCollection<XFTabPage> XFTabPages { get => (ObservableCollection<XFTabPage>)GetValue(TabbedPagesProperty); set => SetValue(TabbedPagesProperty, value); }

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="XFTabControl"/> class.
        /// </summary>
        public XFTabControl()
        {
            Padding = 0;
            Margin = 0;
            init();
            XFTabPages = new ObservableCollection<XFTabPage>();
            XFTabPages.CollectionChanged += XFTabPages_CollectionChanged;
        }

        #endregion

        #region Events

        /// <summary>
        /// Defines the TabClicked.
        /// </summary>
        public event OnTabClickEventHandler TabClicked;

        #endregion

        #region PRIVATE_METHODS

        /// <summary>
        /// The addTabPageContent.
        /// </summary>
        /// <param name="tabPage">The tabPage<see cref="XFTabPage"/>.</param>
        private void addTabPageContent(XFTabPage tabPage)
        {
            tabPage.XFTabParent = this;
            tabPage.Header.XFParentTabPage = tabPage;
            tabPage.Header.BackgroundColor = HeaderColor;
            tabPage.Header.Selector = new BoxView
            {
                BackgroundColor = HeaderColor
            };
            if (tabPage.Header.IsVisible)
            {
                m_Header.Children.Add(tabPage.Header, m_Header.Children.Count, 0);
                m_Selection.Children.Add(tabPage.Header.Selector, m_Selection.Children.Count, 0);
            }
        }

        /// <summary>
        /// The index changed.
        /// </summary>
        /// <param name="bindable">The bindable<see cref="BindableObject"/>.</param>
        /// <param name="oldValue">The oldValue<see cref="object"/>.</param>
        /// <param name="newValue">The newValue<see cref="object"/>.</param>
        private static void IndexChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (XFTabControl)bindable;
            control.SelectTabPage((int)newValue);
        }

        /// <summary>
        /// The init.
        /// </summary>
        private void init()
        {
            m_Parent = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
            XFTabBody = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
            m_Header = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
            m_Selection = new Grid { RowSpacing = 0, ColumnSpacing = 0 };
        }

        /// <summary>
        /// The Tt_PanUpdated.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="PanUpdatedEventArgs"/>.</param>
        private void panGesture_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Running:
                    _SwipeStartX = e.TotalX;
                    _SwipeStartY = e.TotalY;
                    break;
                case GestureStatus.Completed:
                    var xdiff = _SwipeStartX;
                    var ydiff = _SwipeStartY;

                    if (Math.Abs(xdiff) > Math.Abs(ydiff))
                    {
                        if (xdiff < 0 && (SelectedIndex + 1) < m_Header.Children.Count)
                        {
                            SelectedIndex = SelectedIndex + 1;
                        }
                        else if (xdiff > 0 && (SelectedIndex - 1) > -1)
                        {
                            SelectedIndex = SelectedIndex - 1;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// The TabLayout.
        /// </summary>
        private void TabLayout()
        {
            if (Position == Position.Top)
            {
                m_Parent.RowDefinitions = new RowDefinitionCollection
                {
                new RowDefinition { Height = new GridLength(HeaderHeight, GridUnitType.Absolute) },
                new RowDefinition { Height = new GridLength(8, GridUnitType.Absolute) },
                new RowDefinition { Height = GridLength.Star}
                };
                m_Parent.Children.Add(m_Header, 0, 0);
                m_Parent.Children.Add(m_Selection, 0, 1);
                m_Parent.Children.Add(XFTabBody, 0, 2);
            }
            else
            {
                m_Parent.RowDefinitions = new RowDefinitionCollection
                {
                new RowDefinition { Height = GridLength.Star},
                new RowDefinition { Height = new GridLength(8, GridUnitType.Absolute)},
                new RowDefinition { Height = new GridLength(HeaderHeight, GridUnitType.Absolute) }
                };
                m_Parent.Children.Add(XFTabBody, 0, 0);
                m_Parent.Children.Add(m_Selection, 0, 1);
                m_Parent.Children.Add(m_Header, 0, 2);
            }
        }

        /// <summary>
        /// The XFTabPages_CollectionChanged.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/>.</param>
        private void XFTabPages_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    var page = XFTabPages[e.NewStartingIndex];
                    addTabPageContent(page);
                    break;
            }
        }

        #endregion

        #region PUBLIC_METHODS

        /// <summary>
        /// The AddPage.
        /// </summary>
        /// <param name="tabPage">The tabPage<see cref="XFTabPage"/>.</param>
        public void AddPage(XFTabPage tabPage)
        {
            XFTabPages.Add(tabPage);
        }

        /// <summary>
        /// The SelectPage.
        /// </summary>
        /// <param name="index">The index<see cref="int"/>.</param>
        public void SelectTabPage(int index)
        {
            if (index > -1 && m_Header.Children.Count > index)
            {
                var page = (m_Header.Children[index] as XFTabHeader).XFParentTabPage;
                SelectTabPage(page);
            }
        }

        /// <summary>
        /// The SelectTabPage.
        /// </summary>
        /// <param name="page">The page<see cref="XFTabPage"/>.</param>
        public void SelectTabPage(XFTabPage page)
        {
            if (SelectedPage != null)
            {
                SelectedPage.Header.Selector.BackgroundColor = HeaderColor;
                SelectedPage.Header.Opacity = 0.8;
            }
            page.Header.Selector.BackgroundColor = SelectionColor;
            page.Header.Opacity = 1;
            SelectedPage = page;
            XFTabBody.Children.Clear();
            XFTabBody.Children.Add(page.Content);
        }

        #endregion

        /// <summary>
        /// The OnParentSet.
        /// </summary>
        protected override void OnParentSet()
        {
            var panGesture = new PanGestureRecognizer();
            XFTabBody.GestureRecognizers.Add(panGesture);
            panGesture.PanUpdated += panGesture_PanUpdated;
            TabLayout();
            Content = m_Parent;
            SelectTabPage(SelectedIndex);
            SetHeaderColor();
        }

        /// <summary>
        /// The SetHeaderColor.
        /// </summary>
        internal void SetHeaderColor()
        {
            foreach (var page in XFTabPages)
            {
                if (page.Header.HeaderLabel != null)
                {
                    page.Header.HeaderLabel.TextColor = HeaderTextColor;
                }
            }
        }

        /// <summary>
        /// The OnTabClicked.
        /// </summary>
        /// <param name="e">The e<see cref="OnTabClickedEventArgs"/>.</param>
        internal void OnTabClicked(OnTabClickedEventArgs e)
        {
            TabClicked?.Invoke(this, e);
        }
    }
}
