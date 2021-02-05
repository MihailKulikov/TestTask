using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace TestTask
{
    public class OfferViewHolder : RecyclerView.ViewHolder
    {
        public TextView OfferId { get; }
        
        public OfferViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            OfferId = itemView.FindViewById<TextView>(Resource.Id.textView);

            itemView.Click += (sender, args) => listener(LayoutPosition);
        }
    }
}