export function month(monthNumber){
    const months = ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec','Jan'];
    return months[monthNumber-1];
}

export function status(status){
    const statuses = {
        TD: 'Tropical depression',
        TS: 'Tropical storm',
        HU: 'Hurricane',
        EX: 'Extratropical cyclone',
        SD: 'Subtropical depression',
        SS: 'Subtropical storm',
        LO: 'A low',
        WV: 'Tropical wave',
        DB: 'Disturbance',
        'N/A': 'System'
    }
    return statuses[status];
}

export function title(title)
{
    const firstLetter = title[0];
    const rest = title.slice(1);
    const restLower = rest.toLowerCase();

    return `${firstLetter}${restLower}`
}