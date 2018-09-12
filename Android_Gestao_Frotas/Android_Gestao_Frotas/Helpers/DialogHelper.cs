using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Text.Format;
using Android.Views;
using Android.Widget;

namespace Android_Gestao_Frotas.Helpers
{
    public class DialogHelper
    {
        public const string DefaultTitle = "Gestão de Frotas";
        public const string DefaultOk = "Ok";
        public const string DefaultYes = "Sim";
        public const string DefaultNo = "Não";
        public const string DefaultCancel = "Cancelar";
        public const string DefaultHint = "Escreva aqui...";

        private Context _context;
        
        private TaskCompletionSource<DialogResponse> _taskCompletion;

        private bool _cancelable = false;

        public enum DialogResponse
        {
            Ok = 0,
            Yes = 1,
            No = 2,
            Canceled = 3
        }

        public DialogHelper(Context context, bool canCancel = false)
        {
            _context = context;
            _cancelable = canCancel;
        }

        public async Task<DialogResponse> Message(string message, string title = DefaultTitle, string ok = DefaultOk)
        {
            var dialogBuilder = GetBasicAlertDialogBuilder();

            _taskCompletion = new TaskCompletionSource<DialogResponse>();

            dialogBuilder.SetTitle(title);
            dialogBuilder.SetMessage(message);
            dialogBuilder.SetNeutralButton(ok, (neutralSender, neutralArgs) => { NeutralButtonClick(); });

            dialogBuilder.Create().Show();

            var result = await _taskCompletion.Task;

            return result;
        }

        public async Task<DialogResponse> Question(string question, string title = DefaultTitle, string yes = DefaultYes, string no = DefaultNo, string cancel = DefaultCancel)
        {
            var dialogBuilder = GetBasicAlertDialogBuilder();

            _taskCompletion = new TaskCompletionSource<DialogResponse>();

            dialogBuilder.SetTitle(title);
            dialogBuilder.SetMessage(question);
            dialogBuilder.SetPositiveButton(yes, (positiveSender, positiveArgs) => { PositiveButtonClick(); });
            dialogBuilder.SetNegativeButton(no, (negativeSender, negativeArgs) => { NegativeButtonClick(); });
            dialogBuilder.SetNeutralButton(cancel, (neutralSender, neutralArgs) => { CancelButtonClick(); });

            dialogBuilder.Create().Show();

            var result = await _taskCompletion.Task;

            return result;
        }

        public async Task<T> Pick<T>(List<T> list, string title = DefaultTitle, string ok = DefaultOk, string cancel = DefaultCancel)
        {
            var dialogBuilder = GetBasicAlertDialogBuilder();

            var taskCompletionCustom = new TaskCompletionSource<T>();

            dialogBuilder.SetTitle(title);
            dialogBuilder.SetAdapter(
                new ArrayAdapter<T>(_context, Android.Resource.Layout.SimpleListItem1, list), 
                (sender, eventArgs) => { PickItemClick(eventArgs, list, taskCompletionCustom); });
            dialogBuilder.SetNeutralButton(cancel, (neutralSender, neutralArgs) => { CancelButtonClick(); });
            dialogBuilder.Create().Show();

            var result = await taskCompletionCustom.Task;

            return result;
        }

        public async Task<string> UserInput(string message, string text = "", string hintText = DefaultHint, string title = DefaultTitle, string ok = DefaultOk, string cancel = DefaultCancel)
        {
            var dialogBuilder = GetBasicAlertDialogBuilder();

            var taskCompletionCustom = new TaskCompletionSource<string>();

            dialogBuilder.SetTitle(title);
            dialogBuilder.SetMessage(message);
            dialogBuilder.SetView(GetUserInputView(text, hintText));
            dialogBuilder.SetPositiveButton(ok, (positiveSender, positiveArgs) => { UserInputPositiveButtonClick(positiveSender as AlertDialog, taskCompletionCustom); });
            dialogBuilder.SetNeutralButton(cancel, (neutralSender, neutralArgs) => { UserInputNeutralButtonClick(taskCompletionCustom); });
            dialogBuilder.Create().Show();

            var result = await taskCompletionCustom.Task;

            return result;
        }

        public async Task<DateTime> PickDate()
        {
            var taskCompletionCustom = new TaskCompletionSource<DateTime>();

            var datePicker = new DatePickerDialog(_context, 
                (sender, args) => { PositiveDateClick(args, taskCompletionCustom); }, 
                DateTime.Now.Year, 
                DateTime.Now.Month, 
                DateTime.Now.Day);

            datePicker.CancelEvent += delegate { NeutralDateTimeClick(taskCompletionCustom); };

            datePicker.Show();

            var result = await taskCompletionCustom.Task;

            return result;
        }

        public async Task<DateTime> PickDate(int day, int month, int year)
        {
            var taskCompletionCustom = new TaskCompletionSource<DateTime>();

            var datePicker = new DatePickerDialog(_context,
                (sender, args) => { PositiveDateClick(args, taskCompletionCustom); },
                year,
                month,
                day);

            datePicker.CancelEvent += delegate { NeutralDateTimeClick(taskCompletionCustom); };

            datePicker.Show();

            var result = await taskCompletionCustom.Task;

            return result;
        }

        public async Task<DateTime> PickTime(bool is24Format = true)
        {
            var taskCompletionCustom = new TaskCompletionSource<DateTime>();

            var timePicker = new TimePickerDialog(_context,
                (sender, args) => { PositiveTimeClick(args, taskCompletionCustom); },
                DateTime.Now.Hour,
                DateTime.Now.Minute, is24Format);

            timePicker.CancelEvent += delegate { NeutralDateTimeClick(taskCompletionCustom); };

            timePicker.Show();

            var result = await taskCompletionCustom.Task;

            return result;
        }

        public async Task<DateTime> PickTime(int hour, int minute, bool is24Format = true)
        {
            var taskCompletionCustom = new TaskCompletionSource<DateTime>();

            var timePicker = new TimePickerDialog(_context,
                (sender, args) => { PositiveTimeClick(args, taskCompletionCustom); },
                hour,
                minute, is24Format);

            timePicker.CancelEvent += delegate { NeutralDateTimeClick(taskCompletionCustom); };

            timePicker.Show();

            var result = await taskCompletionCustom.Task;

            return result;
        }

        private void NeutralButtonClick()
        {
            _taskCompletion?.TrySetResult(DialogResponse.Ok);
        }

        private void CancelButtonClick()
        {
            _taskCompletion?.TrySetResult(DialogResponse.Canceled);
        }

        private void PositiveButtonClick()
        {
            _taskCompletion?.TrySetResult(DialogResponse.Yes);
        }

        private void UserInputPositiveButtonClick(AlertDialog dialogArgs, TaskCompletionSource<string> taskCompletionCustom)
        {
            var etUserInput = dialogArgs.FindViewById<EditText>(Resource.Id.etUserInput);
            taskCompletionCustom?.TrySetResult(etUserInput.Text);
        }

        private void UserInputNeutralButtonClick(TaskCompletionSource<string> taskCompletionSource)
        {
            taskCompletionSource?.TrySetResult(null);
        }

        private void NegativeButtonClick()
        {
            _taskCompletion?.TrySetResult(DialogResponse.No);
        }

        private void PositiveDateClick(DatePickerDialog.DateSetEventArgs args, TaskCompletionSource<DateTime> taskCompletionSource)
        {
            taskCompletionSource?.TrySetResult(args.Date);
        }

        private void PositiveTimeClick(TimePickerDialog.TimeSetEventArgs args, TaskCompletionSource<DateTime> taskCompletionSource)
        {
            var time = DateTime.MinValue;
            var dateTime = new DateTime(time.Year, time.Month, time.Day, args.HourOfDay, args.Minute, 0);

            taskCompletionSource?.TrySetResult(dateTime);
        }

        private void NeutralDateTimeClick(TaskCompletionSource<DateTime> taskCompletionSource)
        {
            taskCompletionSource?.TrySetResult(DateTime.MinValue);
        }

        private void PickItemClick<T>(DialogClickEventArgs args, List<T> list, TaskCompletionSource<T> taskCompletionCustom)
        {
            if (list == null)
                taskCompletionCustom?.TrySetResult(default(T));

            taskCompletionCustom?.TrySetResult(list[args.Which]);
        }

        private AlertDialog.Builder GetBasicAlertDialogBuilder()
        {
            var dialogBuilder = new AlertDialog.Builder(_context);

            dialogBuilder.SetTitle(DefaultTitle);
            dialogBuilder.SetCancelable(false);

            return dialogBuilder;
        }

        private View GetUserInputView(string text = "", string hintText = "")
        {
            var layoutInflater = LayoutInflater.From(_context);
            var view = layoutInflater.Inflate(Resource.Layout.dialog_user_input, null);

            var etUserInput = view.FindViewById<EditText>(Resource.Id.etUserInput);
            etUserInput.Hint = hintText;
            etUserInput.Text = text;

            return view;
        }
    }
}