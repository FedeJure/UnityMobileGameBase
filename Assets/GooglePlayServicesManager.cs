// using System;
// using System.Threading.Tasks;
// using GooglePlayGames;
// using GooglePlayGames.BasicApi;
// using Unity.Services.Authentication;
// using Unity.Services.Core;
// using UnityEngine;
// using UnityEngine.SocialPlatforms;
//
//     
//     public class GooglePlayServicesManager : MonoBehaviour
//     {
//         public static async Task<bool> Login()
//         {
//             #if UNITY_EDITOR
//             return true;      
//             #endif
//             try
//             {
//                 if (PlayGamesPlatform.Instance.IsAuthenticated())
//                 {
//                     return true;
//                 }
//
//                 var t = new TaskCompletionSource<bool>();
//
//                 PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, async (result) =>
//                 {
//                     try
//                     {
//                         Debug.Log("TOKEN: "+((PlayGamesLocalUser)Social.localUser).GetIdToken() + "ID: " + Social.localUser.id);
//                         await AuthenticationService.Instance.SignInWithGoogleAsync(((PlayGamesLocalUser)Social.localUser).GetIdToken());
//                         t.TrySetResult(SignInStatus.Success.Equals(result));
//                     }
//                     catch (Exception e)
//                     {
//                         t.TrySetResult(false);
//                     }
//                     
//                 });
//
//                 return await t.Task;
//                 
//             }
//             catch (Exception e)
//             {
//                 return false;
//             }
//         }
//
//         public static ILocalUser GetLocalUser()
//         {
//             return Social.localUser;
//         }
//         
//         public static async Task InitializePlayGamesLogin()
//         {
//             var config = new PlayGamesClientConfiguration.Builder()
//                 .RequestServerAuthCode(false)
//                 .RequestIdToken()
//                 .Build();
//             PlayGamesPlatform.InitializeInstance(config);
//             PlayGamesPlatform.DebugLogEnabled = true;
//             PlayGamesPlatform.Activate();
//             await UnityServices.InitializeAsync();
//         }
//
//         public static bool ExistSession()
//         {
//             return AuthenticationService.Instance.SessionTokenExists;
//         }
//
//         public static void LogOut()
//         {
//             AuthenticationService.Instance.SignOut();
//             PlayGamesPlatform.Instance.SignOut();
//         }
//
//     }
