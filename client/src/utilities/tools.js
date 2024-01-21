//Exports month function that takes a number and returns a string that represents said month based on its index position in an array of month strings
export function month(monthNumber){
    const months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec','Jan'];
    return months[monthNumber-1];
}

//Exports status function that returns a string that represents said status based on its corresponding key in an object of statuses
export function status(status){
    const statuses = {
        TD: 'tropical depression',
        TS: 'tropical storm',
        HU: 'hurricane',
        EX: 'extratropical cyclone',
        SD: 'subtropical depression',
        SS: 'subtropical storm',
        LO: 'low',
        WV: 'tropical wave',
        DB: 'disturbance',
        'N/A': 'system'
    };

    return statuses[status];
}

//Exports status function that takes a string parameter and returns said string with the first letter capitalized and the rest in lower case
export function title(title)
{
    const firstLetter = title[0];
    const rest = title.slice(1);
    const restLower = rest.toLowerCase();

    return `${firstLetter}${restLower}`;
}

//Exports named function that takes a name and, if is 'unnamed', returns a string that says 'Unnamed Hurricane', otherwise returning a string that says 'Hurricane {name}' (ex: 'Hurricane Katrina')
export function named(name){
    if (name.toLowerCase() === 'unnamed'){
        return `${name} Hurricane`;
    } else {
        return `Hurricane ${name}`;
    };
}