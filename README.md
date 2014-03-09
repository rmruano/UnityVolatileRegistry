UnityVolatileRegistry
=====================

A small Unity C# class providing singleton capabilities to store volatile data to be accessed from multiple scenes. If you want/need to persist the data, stick to UnityEngine.PlayerPrefs .

Keys are unique per type, you can set two different types for the same key.

Roadmap: 
- [ ] Provide support for 'obscured' integers and floats
- [ ] Integration with PlayerPrefs

Examples
--------
```csharp
using UnityEngine;
using System.Collections;
using Rmruano;

public class ScriptPlayer : MonoBehaviour {
	
	/* Access to the singleton instance */
	protected VolatileRegistry registry = VolatileRegistry.getInstance(); 

	// Use this for initialization
	void Start () {

		// 1. Simple integer
		registry.setInteger ("score", 20);
		print("score = "+registry.getInteger("score").ToString());
		
		// 2. Non existing key
		int? score2 = registry.getInteger("score2");
		if (!score2.HasValue) {
			print("score2 = NULL");
		} else {
			print("score2 = "+score2.ToString()); 
		}
		
		// 3. SubRegistry (registry nesting)
		VolatileRegistry subRegistry = registry.newSubRegistry("mySubRegistry"); // A new VolatileRegistry instance will be automatically generated and stored within the registry.
		subRegistry.setInteger("mySubInteger",10);
		print("mySubRegistry/mySubInteger = "+registry.getSubRegistry("mySubRegistry").getInteger("mySubInteger").ToString ());

	}

}