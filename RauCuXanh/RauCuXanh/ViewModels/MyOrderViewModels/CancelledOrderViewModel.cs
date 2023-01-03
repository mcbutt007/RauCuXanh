﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using RauCuXanh.Models;
using RauCuXanh.Services;
using RauCuXanh.Views.MyOrderViews;
using Xamarin.Forms;
using XF.Material.Forms.UI.Dialogs;

namespace RauCuXanh.ViewModels.MyOrderViewModels
{
    public class CancelledOrderViewModel : BaseViewModel
    {
        public ObservableCollection<Receipt> CancelledOrders { get; set; }
        public Command LoadReceipt { get; set; }
        public Command NavToDetail { get; set; }

        public CancelledOrderViewModel()
        {
            Title = "Đã hủy";
            CancelledOrders = new ObservableCollection<Receipt>();
            LoadReceipt = new Command(async () => await ExeLoadReceiptCommand());
            NavToDetail = new Command<Receipt>(ExeNavToDetail);
        }

        async Task ExeLoadReceiptCommand()
        {
            IsBusy = true;
            try
            {
                CancelledOrders.Clear();
                var receiptService = new ReceiptService();
                var receipts = await receiptService.getReceipts();
                foreach (Receipt receipt in receipts)
                {
                    if (receipt.Order_status == "dahuy")
                    {
                        CancelledOrders.Add(receipt);
                    }
                }
            }
            catch (Exception ex)
            {
                await MaterialDialog.Instance.AlertAsync(message: ex.Message);
            }
            finally { IsBusy = false; }
        }
        public async void ExeNavToDetail(Receipt r)
        {
            await App.Current.MainPage.Navigation.PushAsync(new Views.MyOrderViews.OrderDetailPage(r));
        }

        public void OnAppearing()
        {
            IsBusy= true;
        }
    }
}
