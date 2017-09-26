//                                  ┌∩┐(◣_◢)┌∩┐
//																				\\
// PruebaPCG.cs (26/09/2017)													\\
// Autor: Antonio Mateo (Moon Antonio) 	antoniomt.moon@gmail.com				\\
// Descripcion:		Prueba de PCG												\\
// Fecha Mod:		26/09/2017													\\
// Ultima Mod:		Version Inicial												\\
//******************************************************************************\\

#region Librerias
using UnityEngine;
using System.Collections.Generic;
#endregion

namespace MoonAntonio
{
	/// <summary>
	/// <para>Prueba de PCG.</para>
	/// </summary>
	public class PruebaPCG : MonoBehaviour
	{
		#region Variables Publicas
		/// <summary>
		/// <para>Semilla.</para>
		/// </summary>
		public int seed = 1;										// Semilla
		#endregion

		#region Variables Privadas
		/// <summary>
		/// <para>Palabra procesada.</para>
		/// </summary>
		private string palabraFinal;								// Palabra procesada
		/// <summary>
		/// <para>Lista con las letras iniciales.</para>
		/// </summary>
		private List<string> letras = new List<string>();			// Lista con las letras iniciales
		#endregion

		#region Inicializadores
		/// <summary>
		/// <para>Cargador de <see cref="PruebaPCG"/>.</para>
		/// </summary>
		private void Awake()// Cargador de PruebaPCG
		{
			letras.Add("P");
			letras.Add("R");
			letras.Add("O");
			letras.Add("C");
			letras.Add("E");
			letras.Add("D");
			letras.Add("U");
			letras.Add("R");
			letras.Add("A");
			letras.Add("L");
		}

		/// <summary>
		/// <para>Inicializador de <see cref="PruebaPCG"/>.</para>
		/// </summary>
		private void Start()// Inicializador de PruebaPCG
		{
			// Inicializamos la semilla
			Random.InitState(seed);

			// Obtenemos la palabra final sin procesar y la mostramos
			for (int n = 0; n < letras.Count; n++)
			{
				palabraFinal += letras[n];
			}
			Debug.Log("[NORMAL] Palabra inicial: " + palabraFinal);

			// Reseteamos la palabra
			palabraFinal = "";

			// Procesamos
			while (letras.Count > 0)
			{
				int index = Random.Range(0, letras.Count);
				palabraFinal += letras[index];
				letras.RemoveAt(index);
			}
			Debug.Log("[FIX] Palabra procesada: " + palabraFinal);
		}
		#endregion
	}
}