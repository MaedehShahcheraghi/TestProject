using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TP.Application.Constants;
using TP.Application.Contracts.Infrastructure.CaptchaService;
using TP.Application.Models.Captcha;

namespace TP.Infrastructure.Service
{
    public class CaptchaService : ICaptchaService
    {
        private readonly IMemoryCache _memoryCache; 
        private static readonly Random random = new Random();


        public CaptchaService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public CaptchaResponse GenerateCaptcha(int expireTime,int length)
        {
            var response = new CaptchaResponse();

            try
            {
                var random = new Random();
                var captchaCode = GenerateCaptchaText(length);
                var captchaId = Guid.NewGuid().ToString();

                //Hash captcha code
                var hashedCaptcha = HashCaptchaCode(captchaCode, CaptchaConstant.SecretKey);

                var cacheKey = $"{CaptchaConstant.CaptchaKeyP}{captchaId}";
                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(expireTime));

                _memoryCache.Set(cacheKey, hashedCaptcha, cacheOptions);

                 response = new()
                {
                    CaptchaStatus = (CaptchaStatus)200,
                    CaptchaCode = captchaCode,
                    CaptchaId = captchaId,
                    ExpiryTime = DateTime.UtcNow.AddMinutes(expireTime)

                 };
                return response;    
            }
            catch (Exception)
            {

                return response = new() { CaptchaStatus = (CaptchaStatus)400 };
            }

        }


        public CaptchaStatus ValidateCaptcha(CaptchaValidationRequest captcha)
        {
            try
            {
                var cacheKey = $"{CaptchaConstant.CaptchaKeyP}{captcha.CaptchaId}";

                if (_memoryCache.TryGetValue(cacheKey, out string storedHashedCaptcha))
                {

                    var hashedInput = HashCaptchaCode(captcha.CaptchaCode, CaptchaConstant.SecretKey);
                    if (storedHashedCaptcha == hashedInput)
                    {
                        _memoryCache.Remove(cacheKey);
                        return CaptchaStatus.Ok;
                    }

                    return CaptchaStatus.UnprocessableEntity;
                }
                return CaptchaStatus.Gone;
            }
            catch (Exception)
            {

                return CaptchaStatus.BadRequest;
            
            }

        }

        #region Utitlity

        private static string GenerateCaptchaText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        private string HashCaptchaCode(string captchaCode, string secretKey)
        {
            using var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(secretKey));
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(captchaCode));
            return Convert.ToBase64String(hash);
        }

        #endregion
    }
}
