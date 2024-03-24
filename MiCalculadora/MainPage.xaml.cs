using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

/*Este backend del programa permite la realización de los cálculos necesario para poder
 * darle funcionalidad a la calculadora, como lo son los botones de números o de operaciones
 * con tal de obtener un resultado correcto.
 * 
 Autor:Alejandro González Zárate*/

namespace MiCalculadora
{
    /*Clase que contiene los métodos necesarios para poder administrar el manejo y funcionamiento de
     * los botones. Algunas de estos son el recibir la entrada de numeros, puntos decimales y operaciones
     * como suma/resta.
     */
    public partial class MainPage : ContentPage
    {
        //Atributos
        private String operacion;
        private double num1;
        private double num2;
        private double memoria;
        private double resultado;

        //Metodo constructor
        public MainPage()
        {
            InitializeComponent();
            resultado = 0;
        }

        //Almacena en memoria un cantidad
        private void btnMS_Clicked(object sender, EventArgs e)
        {
            if (!lblScreen.Text.Equals("Error"))
            {
                memoria = Convert.ToDouble(lblScreen.Text);
                btnMR.IsEnabled = true;
            }

        }

        //Calcula el Inverso de una cantidad
        private void btnInverso_Clicked(object sender, EventArgs e)
        {
            if (!lblScreen.Text.Equals("Error"))
            {
                num1 = Convert.ToDouble(lblScreen.Text);
                if (num1 != 0)
                {
                    resultado = 1 / num1;
                    lblScreen.Text = resultado.ToString();
                }
                else
                {
                    lblScreen.Text = "Error";
                }
            }

        }

        //Permite recuperar una cantidad almacenada
        private void btnMR_Clicked(object sender, EventArgs e)
        {
            if (!lblScreen.Text.Equals("Error"))
            {
                lblScreen.Text = memoria.ToString();
            }
        }

        //Limpia la entrada actual
        private void btnClear_Clicked(object sender, EventArgs e)
        {
            lblScreen.Text = "0";
            num1 = 0;
            num2 = 0;
        }

        //Eleva una cantidad al cuadrado
        private void btnCuadrado_Clicked(object sender, EventArgs e)
        {
            if (!lblScreen.Text.Equals("Error"))
            {
                num1 = Convert.ToDouble(lblScreen.Text);
                if (num1 != 0)
                {
                    resultado *=resultado ;
                    lblScreen.Text = resultado.ToString();
                }
                else
                {
                    lblScreen.Text = "Error";
                }
            }

        }

        //Calcula la raiz cuadrada de un numero
        private void btnRaiz_Clicked(object sender, EventArgs e)
        {
            if (!lblScreen.Text.Equals("Error"))
            {
                num1 = Convert.ToDouble(lblScreen.Text);
                if (num1 != 0)
                {
                    resultado = Math.Sqrt(resultado);
                    lblScreen.Text = resultado.ToString();
                }
                else
                {
                    lblScreen.Text = "Error";
                }
            }
            

        }

        //Almacenar en la variable la operacion escogida y el primer numero escrito
        //Junto con otros manejadores, se obtiene el resultado final de 2 numeros
        private void btnOperacion_Clicked(object sender, EventArgs e)
        {
            var botonOp = (Button)sender;

            //Se define la operación en base al boton seleccionado
            switch (botonOp.Text)
            {
                case "+":
                    operacion = "suma";
                    break;
                case "\u2212":
                    operacion = "resta";
                    break;
                case "x":
                    operacion = "multiplicacion";
                    break;
                case "\u00F7":
                    operacion = "division";
                    break;
            }
            //En caso de que este vacio y se de clic a un boton de operacion, se muestra el mensaje Error
            if (String.IsNullOrEmpty(lblScreen.Text) || lblScreen.Text.Contains("Error"))
            {
                lblScreen.Text = "Error";
            }
            else
            {
                num1 = Convert.ToDouble(lblScreen.Text);
                lblScreen.Text = "0";
            }

            

        }

        //Mostrar en pantalla los digitos pulsados para formar una cadena que represente un numero decimal
        private void btnNum_Clicked(object sender, EventArgs e)
        {
            Button botonDigito = (Button)sender;

            if (resultado != 0 || lblScreen.Text == "Error")
            {
                lblScreen.Text = "0";
            }

            if (lblScreen.Text == "0")
            {
                lblScreen.Text = "";
                resultado = 0;
            }

            if (botonDigito.Text != ".")
            {
                lblScreen.Text = lblScreen.Text + botonDigito.Text;
            }

            else if (!lblScreen.Text.Contains("."))
            {
                lblScreen.Text = lblScreen.Text + ".";
            }

        }

        //Se almacena el segundo numero de la operacion y se lleva a cabo la operacion correspondiente
        private void btnIgual_Clicked(object sender, EventArgs e)
        {
            //Se usa este metodo en un caso de que no haya ningun string,pues llega a causar error. 
            if (String.IsNullOrEmpty(lblScreen.Text))
            {
                //Reinicializa la calculadora
                lblScreen.Text = "0";
                num1 = 0;
                num2 = 0;
            }

            else if (lblScreen.Text.Contains("Error"))
            {
                //Se seguira mostrando error porque no se puede trabajar con un error
                lblScreen.Text = "Error";
            }
            else
            {
                num2 = Convert.ToDouble(lblScreen.Text);
                bool esCero = false;    //Permite saber si num2 es 0

                //Se realiza la operación correspondiente entre num1/2
                switch (operacion)
                {
                    case "suma":
                        resultado = num1 + num2;
                        break;
                    case "resta":
                        resultado = num1 - num2;
                        break;
                    case "multiplicacion":
                        resultado = num1 * num2;
                        break;
                    case "division":
                        //Division cuando num2 !0
                        if (num2 != 0)
                        {
                            resultado = num1 / num2;
                        }

                        //Cuando si es cero num2
                        else
                            esCero = true;
                        break;
                }

                //Caso normal
                if (esCero != true)
                    lblScreen.Text = resultado.ToString();
                //Caso alterno
                else
                    lblScreen.Text = "Error";

            }
            

        }
    }
}
