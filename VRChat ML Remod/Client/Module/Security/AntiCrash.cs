using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DeepCore.Client.Module.Security
{
    internal class AntiCrash
    {
        public static void CheckForClean(GameObject param_0)
        {
            if (param_0.name.ToLower().Contains("Avatar"))
            {
                CleanAvatar(param_0);
            }
        }
        public static void CleanAvatar(GameObject gameObject)
        {
            if (true)
            {
                List<AudioSource> transforms = new List<AudioSource>();
                gameObject.GetComponents<AudioSource>().ToList<AudioSource>().ForEach(delegate (AudioSource transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInChildren<AudioSource>().ToList<AudioSource>().ForEach(delegate (AudioSource transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInParent<AudioSource>().ToList<AudioSource>().ForEach(delegate (AudioSource transform)
                {
                    transforms.Add(transform);
                });
                if (transforms.Count > 45)
                {
                    for (int i = 0; i < transforms.Count; i++)
                    {
                        Object.DestroyImmediate(transforms[i], true);
                    }
                    DeepConsole.Log("AntiCrash", string.Format("Deleted a total of {0} AudioSources from someones avatar!", transforms.Count));
                }
            }
            if (true)
            {
                List<Transform> transforms = new List<Transform>();
                gameObject.GetComponents<Transform>().ToList<Transform>().ForEach(delegate (Transform transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInChildren<Transform>().ToList<Transform>().ForEach(delegate (Transform transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInParent<Transform>().ToList<Transform>().ForEach(delegate (Transform transform)
                {
                    transforms.Add(transform);
                });
                if (transforms.Count > 20000)
                {
                    for (int j = 0; j < transforms.Count; j++)
                    {
                        Object.DestroyImmediate(transforms[j], true);
                    }
                    DeepConsole.Log("AntiCrash",string.Format("Deleted a total of {0} Transforms from someones avatar!", transforms.Count));
                }
            }
            if (true)
            {
                List<Rigidbody> transforms = new List<Rigidbody>();
                gameObject.GetComponents<Rigidbody>().ToList<Rigidbody>().ForEach(delegate (Rigidbody transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInChildren<Rigidbody>().ToList<Rigidbody>().ForEach(delegate (Rigidbody transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInParent<Rigidbody>().ToList<Rigidbody>().ForEach(delegate (Rigidbody transform)
                {
                    transforms.Add(transform);
                });
                if (transforms.Count > 20000)
                {
                    for (int k = 0; k < transforms.Count; k++)
                    {
                        Object.DestroyImmediate(transforms[k], true);
                    }
                    DeepConsole.Log("AntiCrash", string.Format("Deleted a total of {0} Rigidbodies from someones avatar!", transforms.Count));
                }
            }
            if (true)
            {
                List<Collider> transforms = new List<Collider>();
                gameObject.GetComponents<Collider>().ToList<Collider>().ForEach(delegate (Collider transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInChildren<Collider>().ToList<Collider>().ForEach(delegate (Collider transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInParent<Collider>().ToList<Collider>().ForEach(delegate (Collider transform)
                {
                    transforms.Add(transform);
                });
                if (transforms.Count > 20000)
                {
                    for (int l = 0; l < transforms.Count; l++)
                    {
                        Object.DestroyImmediate(transforms[l], true);
                    }
                    DeepConsole.Log("AntiCrash", string.Format("Deleted a total of {0} Colliders from someones avatar!", transforms.Count));
                }
            }
            if (true)
            {
                List<Shader> transforms = new List<Shader>();
                gameObject.GetComponents<Shader>().ToList<Shader>().ForEach(delegate (Shader transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInChildren<Shader>().ToList<Shader>().ForEach(delegate (Shader transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInParent<Shader>().ToList<Shader>().ForEach(delegate (Shader transform)
                {
                    transforms.Add(transform);
                });
                if (transforms.Count > 45)
                {
                    for (int m = 0; m < transforms.Count; m++)
                    {
                        Object.DestroyImmediate(transforms[m], true);
                    }
                    DeepConsole.Log("AntiCrash", string.Format("Deleted a total of {0} Shaders from someones avatar!", transforms.Count));
                }
            }
            if (true)
            {
                List<Mesh> transforms = new List<Mesh>();
                gameObject.GetComponents<Mesh>().ToList<Mesh>().ForEach(delegate (Mesh transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInChildren<Mesh>().ToList<Mesh>().ForEach(delegate (Mesh transform)
                {
                    transforms.Add(transform);
                });
                gameObject.GetComponentsInParent<Mesh>().ToList<Mesh>().ForEach(delegate (Mesh transform)
                {
                    transforms.Add(transform);
                });
                if (transforms.Count > 45)
                {
                    for (int n = 0; n < transforms.Count; n++)
                    {
                        Object.DestroyImmediate(transforms[n], true);
                    }
                    DeepConsole.Log("AntiCrash", string.Format("Deleted a total of {0} AudioSources from someones avatar!", transforms.Count));
                }
            }
        }
    }
}
