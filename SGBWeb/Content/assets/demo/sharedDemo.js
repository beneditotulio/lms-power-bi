$(document).ready(function () {


    //Input Money Mask
    let input = SimpleMaskMoney.setMask('#price'); 
});

let input = SimpleMaskMoney.setMask('#price',{
        prefix: '',
        suffix: '',
        fixed: true,
        fractionDigits: 2,
        decimalSeparator: ',',
        thousandsSeparator: '.',
        emptyOrInvalid: () => {
          return this.SimpleMaskMoney.args.fixed
            ? `0${this.SimpleMaskMoney.args.decimalSeparator}00`
            : `_${this.SimpleMaskMoney.args.decimalSeparator}__`;
        }
        });