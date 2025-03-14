const CookieHelper = {
    setCookie: function (
      name: string,
      value: string,
      day?: number,
      path?: string
    ): void {
      const expires = day
        ? new Date(Date.now() + day * 24 * 60 * 60 * 1000)
        : undefined;
  
      document.cookie = `${name}=${value};${
        expires ? `expires=${expires.toUTCString()};` : ''
      }path=${path}`;
    },
  
    removeCookie: function (name: string, path: string): void {
      document.cookie = `${name}=;expires=Thu, 01 Jan 1970 00:00:00 UTC;path=${path}`;
    },
  
    getCookie: function (name: string): string {
      const cookies = document.cookie.split(';').map((cookie) => cookie.trim());
      for (const cookie of cookies) {
        const [cookieName, cookieValue] = cookie.split('=');
        if (cookieName === name) {
          return cookieValue;
        }
      }
      return '';
    },
  };
  
  export default CookieHelper;
  