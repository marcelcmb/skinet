let data: number | string; // either a type of number or a type of string
data = '42';
data  = 10;

interface ICar {
    color: string;
    model: string;
    topSpeed?: number;  // ? means optional field
}

const car1: ICar = {
    color: 'blue',
    model: 'bmw'
};

const car2: ICar = {
    color: 'red',
    model: 'mercedes',
    topSpeed: 100
};

const multiply = (x: number, y: number): string => {
    return (x * y).toString();
};
