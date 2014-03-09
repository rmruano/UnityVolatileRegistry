using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Rmruano {

	public class VolatileRegistry {

		/**
		 * Instance holder
		 */
		protected static VolatileRegistry instance;

		protected Dictionary<string, int> dIntegers = new Dictionary<string, int>();
		protected Dictionary<string, float> dFloats = new Dictionary<string, float>();
		protected Dictionary<string, string> dStrings = new Dictionary<string, string>();
		protected Dictionary<string, ArrayList> dArrays = new Dictionary<string, ArrayList>();
		protected Dictionary<string, VolatileRegistry> dRegistries = new Dictionary<string, VolatileRegistry>();
		
		/**
		 * Gets the singleton instance
		 */
		public static VolatileRegistry getInstance() {
			if (instance == null) {
				instance = new VolatileRegistry();
			}
			return instance;
		}

		/**
		 * Protected constructor. No new instances allowed.
		 */ 
		protected VolatileRegistry() {}

		/**
		 * Stores an integer
		 */
		public void setInteger(string key, int value) {
			dIntegers [key] = value;
		}

		/**
		 * Stores a string
		 */ 
		public void setString(string key, string value) {
			dStrings [key] = value;
		}

		/**
		 * Stores a float
		 */
		public void setFloat(string key, float value) {
			dFloats [key] = value;
		}

		/**
		 * Stores an ArrayList
		 */
		public void setArray(string key, ArrayList array) {
			dArrays [key] = array;
		}

		/**
		 * Stores a Sub Registry (another VolatileRegistry instance)
		 */
		public void setSubRegistry(string key, VolatileRegistry registry) {
			dRegistries [key] = registry;
		}

		/**
		 * Creates and stores a Sub Registry (another VolatileRegistry instance).
		 */ 
		public VolatileRegistry newSubRegistry(string key) {
			VolatileRegistry registry = new VolatileRegistry ();		
			this.setSubRegistry (key, registry);
			return registry;
		}

		/**
		 * Gets an integer from the Registry, default value can be provided in case it's not found.
		 */
		public int? getInteger(string key, int? defaultValue) {
			if (dIntegers.ContainsKey (key)) {
				return dIntegers [key];
			}
			return defaultValue;
		}

		/**
		 * Gets an integer from the Registry. Null if not found.
		 */
		public int? getInteger(string key) {
			return this.getInteger (key, null);
		}

		/**
		 * Gets a float from the Registry, default value can be provided in case it's not found.
		 */ 
		public float? getFloat(string key, float? defaultValue) {
			if (dFloats.ContainsKey (key)) {
				return dFloats [key];
			}
			return defaultValue;
		}
		
		/**
		 * Gets a float from the Registry. Null if not found.
		 */
		public float? getFloat(string key) {
			return this.getFloat (key, null);
		}

		/**
		 * Gets a string from the Registry, default value can be provided in case it's not found.
		 */
		public string getString(string key, string defaultValue) {
			if (dStrings.ContainsKey (key)) {
				return dStrings [key];
			}
			return null;
		}

		/**
		 * Gets a string from the Registry. Null if not found.
		 */
		public string getString(string key) {
			return this.getString (key, null);
		}

		/**
		 * Get an ArrayList from the Registry. Null if not found.
		 */
		public ArrayList getArray(string key) {
			if (dArrays.ContainsKey (key)) {
				return dArrays [key];
			}
			return null;
		}

		/**
		 * Gets a child registry (another VolatileRegistry instance) from the Registry.
		 */
		public VolatileRegistry getSubRegistry(string key) {
			if (dRegistries.ContainsKey (key)) {
				return dRegistries [key];
			}
			return null;
		}

		/**
		 * Get the integers dictionary.
		 */
		public Dictionary<string, int> getIntegers() {
			return dIntegers;
		}

		/**
		 * Get the floats dictionary.
		 */
		public Dictionary<string, float> getFloats() {
			return dFloats;
		}

		/**
		 * Get the strings dictionary
		 */
		public Dictionary<string, string> getStrings() {
			return dStrings;
		}

		/**
		 * Gets the ArrayLists dictionary
		 */
		public Dictionary<string, ArrayList> getArrays() {
			return dArrays;
		}

		/**
		 * Gets the SubRegistries (VolatileRegistry) dictionary
		 */
		public Dictionary<string, VolatileRegistry> getSubRegistries() {
			return dRegistries;
		}

			
	}
}