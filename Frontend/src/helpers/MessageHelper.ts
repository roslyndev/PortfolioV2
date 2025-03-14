import Swal from 'sweetalert2';

const MessageHelper = {
  Alert: function (msg:string, callback?:() => void) {
    Swal.fire({
      title: msg,
      icon: 'error',
      confirmButtonColor: '#dc3545',
    }).then(() => {
      if (callback !== null && callback !== undefined) callback();
    });
  },
  Confirm: function (msg:string, callback?:() => void) {
    Swal.fire({
      title: msg,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'OK',
    }).then((result) => {
      if (callback !== null && callback !== undefined) {
        if (result.isConfirmed) {
          callback();
        }
      }
    });
  },
  Success: function (msg:string, callback?:() => void) {
    Swal.fire({
      title: msg,
      icon: 'success',
      confirmButtonColor: '#28a745',
    }).then(() => {
      if (callback !== null && callback !== undefined) callback();
    });
  },
  Console: function (promptMsg:string, callback:(t:any) => void) {
    Swal.fire({
      title: promptMsg,
      input: 'text',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'OK',
      inputValidator: (value) => {
        if (!value) {
          return '필수 항목입니다.';
        }
      },
    }).then((result) => {
      if (result.isConfirmed) {
        callback(result.value);
      }
    });
  },
  Edit: function (promptMsg:string, initialValue:string, callback:(t:any) => void) {
    Swal.fire({
      title: promptMsg,
      input: 'text',
      inputValue: initialValue, // 초기값 설정
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'OK',
      inputValidator: (value) => {
        if (!value) {
          return '필수 항목입니다.';
        }
      },
    }).then((result) => {
      if (result.isConfirmed) {
        callback(result.value);
      }
    });
  },
};

export default MessageHelper;
