//Exports month function that takes a number and returns a string that represents said month based on its index position in an array of month strings
export function month(monthNumber){
    const months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec','Jan'];
    return months[monthNumber-1];
}

//Exports status function that returns a string that represents a statusId based on its corresponding key in an object of statuses
export function status(statusId){
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

    return statuses[statusId];
}

//Exports status function that takes a string parameter and returns said string with the first letter capitalized and the rest in lower case
export function title(unformattedTitle)
{
    const firstLetter = unformattedTitle[0];
    const rest = unformattedTitle.slice(1);
    const restLower = rest.toLowerCase();

    return `${firstLetter}${restLower}`;
}

//Exports named function that takes a name and, if is 'unnamed', returns a string that says 'Unnamed Hurricane', otherwise returning a string that says 'Hurricane {name}' (ex: 'Hurricane Katrina')
export function named(baseName){
    if (baseName.toLowerCase() === 'unnamed'){
        return `${baseName} Hurricane`;
    } else {
        return `Hurricane ${baseName}`;
    };
}