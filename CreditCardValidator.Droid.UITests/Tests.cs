using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace CreditCardValidator.Droid.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
		}

        [Test]
        public void TitleShouldBeDisplayed()
        {
            app.Screenshot("Title");
            Assert.True(app.Query("Enter Credit Card Number").Any());
        }

        [Test]
        public void TooShortMessageShouldBeDisplayed()
        {
            app.Tap("creditCardNumberText");
            app.EnterText("5555");
            app.Tap("Validate Credit Card");
            Assert.True(app.Query("Credit card number is too short.").Any());
        }

        [Test]
        public void TooLongMessageShouldBeDisplayed()
        {
            app.Tap("creditCardNumberText");
            app.EnterText("555555555555555555");
            app.Tap("Validate Credit Card");
            Assert.True(app.Query("Credit card number is too long.").Any());
        }

    }
}

