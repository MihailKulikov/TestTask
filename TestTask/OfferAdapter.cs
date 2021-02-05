using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using TestTask.Models;

namespace TestTask
{
    public sealed class OfferAdapter : RecyclerView.Adapter
    {
        private readonly List<Offer> offers;
        public event EventHandler<int> ItemClick;

        public OfferAdapter(List<Offer> offers)
        {
            this.offers = offers;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((OfferViewHolder) holder).OfferId.Text = offers[position].Id;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType) =>
            new OfferViewHolder(LayoutInflater.From(parent.Context)
                ?.Inflate(Resource.Layout.item_view, parent, false), OnItemClick);

        public override int ItemCount => offers.Count;

        private void OnItemClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }
    }
}