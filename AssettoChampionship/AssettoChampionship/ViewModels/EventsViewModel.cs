﻿using Assetto.Common.Data;
using Assetto.Common.Framework;
using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assetto.Common.DTO;
using Assetto.Common.Interfaces.Manager;

namespace AssettoChampionship.ViewModels
{
    public class EventsViewModel : Screen
    {
        #region Properties

        private Guid _selectedSeriesId;

        private SeriesDTO _series;
        public SeriesDTO Series {
            get
            {
                return _series;
            }
            set
            {
                _series = value;
                NotifyOfPropertyChange(() => Series);
            }
        }

        #endregion

        #region BindedProperties

        private BindableCollection<EventData> _events { get; set; }
        public BindableCollection<EventData> Events
        {
            get { return _events; }
            set
            {
                _events = value;
                NotifyOfPropertyChange(() => Events);
            }
        }

        #endregion

        #region Injected

        // Managers
        public IEventAggregator EventAggregator { get; set; }
        public ISeriesManager SeriesManager { get; set; }

        #endregion

        public EventsViewModel(IEventAggregator eventAggregator
            , ISeriesManager seriesManager)
        {
            this.EventAggregator = eventAggregator;
            this.SeriesManager = seriesManager;
        }

        public void SetSeries(Guid seriesId)
        {
            this.Series = SeriesManager.GetSeries(seriesId);
            this._selectedSeriesId = seriesId;
        }

        public void EventSelected(Guid eventId)
        {
            if (this.Series.Events.FirstOrDefault(e => e.EventId == eventId).IsAvailable)
            {
                this.EventAggregator.Publish(new ChangePageMessage(typeof(SessionsViewModel), new ChangePageParameters()
                {
                    SelectedSeriesId = this.Series.SeriesId,
                    SelectedEventId = eventId
                }), action => { Task.Factory.StartNew(action); });
            }
        }

        protected override void OnActivate()
        {
            RefreshData();
            base.OnActivate();
        }

        private void RefreshData()
        {
            this.Series = SeriesManager.GetSeries(this._selectedSeriesId);
        }

    }
}
