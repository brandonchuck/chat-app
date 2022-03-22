import React from "react";

const Message = ({ username, text }) => {
  return (
    <div className="bg-blue-500 rounded-lg py-1 px-2 text-slate-100 my-1">
      {username}: {text}
    </div>
  );
};

export default Message;
