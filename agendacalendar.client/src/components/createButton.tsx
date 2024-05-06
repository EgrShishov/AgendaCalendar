import React, {useContext, useState} from "react";
import GlobalContext from "../context/globalContext.ts";
import Button from '@mui/material/Button';
import Menu from '@mui/material/Menu';
import MenuItem from '@mui/material/MenuItem';

const CreateButton = () => {
    const { setShowEventDetails, setShowCalendarModal, setShowReminderModal } = useContext(GlobalContext)

    const [showPopover, setShowPopover] = useState(false);
    const [anchorEl, setAnchorEl] = useState(null);

    const handleClick = (event) => {
        setAnchorEl(event.currentTarget);
    };

    const handleClose = () => {
        setAnchorEl(null);
    };

    const handleAddItem = (item) => {
        setShowPopover(false);
        console.log(item);
        if (item == 'event') {
            setShowEventDetails(true);
            setShowCalendarModal(false);
            setShowReminderModal(false);
        } else if (item == 'calendar') {
            setShowEventDetails(false);
            setShowCalendarModal(true);
            setShowReminderModal(false);
        } else if(item == 'reminder'){
            setShowEventDetails(false);
            setShowCalendarModal(false);
            setShowReminderModal(true);
        }
        handleClose();
    };

    return (
        <React.Fragment>
            <Button className="bg-white border p-2" onClick={handleClick} variant="contained">
                <span className="text-orange-400 font-bold text-2xl material-icons-outlined w-7 h-7">
                    add
                </span>
                    <span className="text-orange-400 font-bold text-xl pl-3 pr-7">Create</span>
            </Button>
            <Menu
                anchorEl={anchorEl}
                open={Boolean(anchorEl)}
                onClose={handleClose}
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'left',
                }}
            >
                <MenuItem onClick={() => handleAddItem('calendar')}>Calendar</MenuItem>
                <MenuItem onClick={() => handleAddItem('event')}>Event</MenuItem>
                <MenuItem onClick={() => handleAddItem('reminder')}>Reminder</MenuItem>
            </Menu>
        </React.Fragment>
    );
};

export default CreateButton;
