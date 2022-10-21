using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Servicios;

namespace Test
{
	/*
	 * La clave debe tener:
	 * -Al menos 1 mayuscula
	 * -Al menos 1 minuscula
	 * -6 caracteres como minimo
	 * -12 caracteres como maximo
	 * -Al menos 1 caracter especial (@/_-)
	 * -Al menos 1 digito
	 */
	class ClaveTest
	{
		ServicioClave claveServicio;
		[SetUp]
		public void SetUp() {
			ServicioClave claveServicio = new ServicioClave();
		}

		[TestCase("1234@", false)]
		[TestCase("12345678912ASZzx@_", false)]
		[TestCase("clave123", false)]
		[TestCase("clave123_x", false)]
		[TestCase("Clave123_X", true)]
		public void Validar_Composicion_Clave(string clave, bool esperado) 
		{			
			//When
			bool actual = claveServicio.ValidarClave(clave);
			//Then
			Assert.AreEqual(actual, esperado);
		}

		[TestCase("Axz19",true)]
		[TestCase("axz19", false)]
		[TestCase("jsdajxFsda", true)]
		[TestCase("123adaA", true)]
		public void Calve_Debe_Tener_Almenos_1_Mayuscula(string clave, bool esperado) 
		{
			//When
			bool actual = claveServicio.ValidarMayuscula(clave);
			//Then
			Assert.AreEqual(actual, esperado);
		}

		[TestCase("X90A123", false)]
		[TestCase("AAAAAAAAA", false)]
		[TestCase("jsdajx233AASX", true)]
		[TestCase("aXXXXXa", true)]
		[TestCase("12345AB", false)]
		public void Clave_Debe_Tener_Almenos_1_Minuscula(string clave, bool esperado) 
		{
			//When
			bool resultado = claveServicio.ValidarMinuscula(clave);
			//Then
			Assert.AreEqual(resultado, esperado);
		}

		[TestCase("123", false)]
		[TestCase("123456", true)]
		[TestCase("80902", false)]
		[TestCase("xMA321", true)]
		[TestCase("POyx9012er81", true)]
		[TestCase("000000eeaattMAXMIN", false)]
		public void Clave_Debe_Tener_Longitud_Maxima_Entre_16_y_12Caracteres(string clave, bool esperado)
		{
			//When
			bool resultado = claveServicio.ValidarLongitudClave(clave);
			//Then
			Assert.AreEqual(resultado, esperado);
		}

		[TestCase("Mxz@pop12", true)]
		[TestCase("Maxsdd1233", false)]
		[TestCase("as_@ssii1", true)]
		[TestCase("POPASSD", false)]
		public void Clave_Debe_Tener_Almenos_1_Caractere_Especial(string clave, bool esperado)
		{
			//When
			bool resultado = claveServicio.ValidarCaracterEspecialClave(clave);
			//Then
			Assert.AreEqual(esperado, resultado);
		}

		[TestCase("12313129", true)]
		[TestCase("axcaASD@_", false)]
		[TestCase("ipascqweeAXCA@_2", true)]
		[TestCase("AAXCpioxASD21", true)]
		public void Clave_Debe_Tener_Almenos_1_Digito(string clave, bool esperado)
		{
			//When
			bool resultado = claveServicio.ValidarDigito(clave);
			//Then
			Assert.AreEqual(esperado, resultado);
		}
	}
}
