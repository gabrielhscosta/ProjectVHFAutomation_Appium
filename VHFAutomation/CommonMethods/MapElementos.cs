using System;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using VHFAutomation.PageObjects;

namespace VHFAutomation.CommonMethods
{
    public static class Elementos
    {

        public static WindowsElement EncontraElementoTagName(
            this WindowsDriver<WindowsElement> acessarModulo,
            string Identificador,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            System.Threading.Thread.Sleep(2000);
            while (nTryCount-- > 0)
            {
                try
                {
                    acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
                    System.Threading.Thread.Sleep(500);
                    uiTarget = acessarModulo.FindElementByTagName(Identificador);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            return uiTarget;
        }

        public static WindowsElement EncontraElementoName(
            this WindowsDriver<WindowsElement> acessarModulo,
            string Name,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            System.Threading.Thread.Sleep(2000);
            while (nTryCount-- > 0)
            {
                try
                {
                    acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
                    System.Threading.Thread.Sleep(500);
                    uiTarget = acessarModulo.FindElementByName(Name);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            return uiTarget;
        }

        public static WindowsElement EncontraElementoClassName(
            this WindowsDriver<WindowsElement> acessarModulo,
            string className,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            System.Threading.Thread.Sleep(2000);
            while (nTryCount-- > 0)
            {
                try
                {
                    acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
                    System.Threading.Thread.Sleep(500);
                    uiTarget = acessarModulo.FindElementByClassName(className);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            return uiTarget;
        }

        public static WindowsElement EncontraElementoAutomationId(
            this WindowsDriver<WindowsElement> acessarModulo,
            string Identificador,
            int nTryCount = 3)
        {
            WindowsElement uiTarget = null;
            System.Threading.Thread.Sleep(2000);
            while (nTryCount-- > 0)
            {
                try
                {
                    acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
                    System.Threading.Thread.Sleep(500);
                    uiTarget = acessarModulo.FindElementByAccessibilityId(Identificador);
                }
                catch
                {
                }
                if (uiTarget != null)
                {
                    break;
                }
                else
                {
                    System.Threading.Thread.Sleep(500);
                }
            }
            return uiTarget;
        }

        public static IReadOnlyCollection<WindowsElement> EncontraElementosName(
           this WindowsDriver<WindowsElement> acessarModulo,
           string name)
        {
            IReadOnlyCollection<WindowsElement> elementos = null;
            WebDriverWait waitForMe = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(120));
            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
            elementos = acessarModulo.FindElementsByName(name);
            waitForMe.Until(pred => elementos.Count() != 0);
            return elementos;
        }

        public static IReadOnlyCollection<WindowsElement> EncontraElementosClassName(
           this WindowsDriver<WindowsElement> acessarModulo, string ClassName)
        {
            IReadOnlyCollection<WindowsElement> elementos = null;
            WebDriverWait waitForMe = new WebDriverWait(acessarModulo, TimeSpan.FromSeconds(120));
            acessarModulo.SwitchTo().Window(acessarModulo.WindowHandles.First());
            elementos = acessarModulo.FindElementsByClassName(ClassName);
            waitForMe.Until(pred => elementos.Count() != 0);
            return elementos;
        }
    }
}